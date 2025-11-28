using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class TestSuite
{
    private GameObject gmGO;
    private GameObject ballGO;
    private GameObject resetGO;

    private GameManager gm;
    private BallController ball;
    private BallResetService resetService;

    [SetUp]
    public void Setup()
    {
        // --- Limpiar singleton previo de GameManager (si hubiera) ---
        var instanceProp = typeof(GameManager)
            .GetProperty("instance", BindingFlags.Static | BindingFlags.Public);
        if (instanceProp != null)
        {
            instanceProp.SetValue(null, null);   // GameManager.instance = null;
        }

        // --- Crear pelota ---
        ballGO = new GameObject("Ball");
        var rb = ballGO.AddComponent<Rigidbody2D>();   // Rigidbody primero
        ball = ballGO.AddComponent<BallController>();  // luego BallController (Awake toma el rb)

        // --- Crear BallResetService ---
        resetGO = new GameObject("BallResetService");
        resetService = resetGO.AddComponent<BallResetService>();

        // Asignar la pelota al campo privado 'ball' de BallResetService
        var ballField = typeof(BallResetService)
            .GetField("ball", BindingFlags.NonPublic | BindingFlags.Instance);
        ballField.SetValue(resetService, ball);

        // --- Crear GameManager ---
        gmGO = new GameObject("GameManager");
        gm = gmGO.AddComponent<GameManager>();   // Awake crea InMemoryScoreService

        // Asignar BallResetService al campo privado 'ballResetService' de GameManager
        var resetServiceField = typeof(GameManager)
            .GetField("ballResetService", BindingFlags.NonPublic | BindingFlags.Instance);
        resetServiceField.SetValue(gm, resetService);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gmGO);
        Object.DestroyImmediate(ballGO);
        Object.DestroyImmediate(resetGO);
    }

    // ─────────────────────────────────────────────────────────────
    // TEST 1 — Player1 anota → scoreP1 aumenta
    // ─────────────────────────────────────────────────────────────
    [Test]
    public void Player1Scores_IncreasesP1()
    {
        gm.ScorePoint(true);

        Assert.AreEqual(1, gm.scoreP1, "El score del Player 1 debería ser 1");
        Assert.AreEqual(0, gm.scoreP2, "El score del Player 2 debería ser 0");
    }

    // ─────────────────────────────────────────────────────────────
    // TEST 2 — Player2 anota → scoreP2 aumenta
    // ─────────────────────────────────────────────────────────────
    [Test]
    public void Player2Scores_IncreasesP2()
    {
        gm.ScorePoint(false);

        Assert.AreEqual(0, gm.scoreP1, "El score del Player 1 debería ser 0");
        Assert.AreEqual(1, gm.scoreP2, "El score del Player 2 debería ser 1");
    }

    // ─────────────────────────────────────────────────────────────
    // TEST 3 — ScorePoint resetea la pelota al centro
    // ─────────────────────────────────────────────────────────────
    [Test]
    public void ScorePoint_ResetsBallToCenter()
    {
        // Ponemos la pelota en una posición cualquiera
        ball.transform.position = new Vector2(5f, 3f);

        gm.ScorePoint(true);

        // BallResetService llama a ball.ResetToCenterAndLaunch(),
        // que pone transform.position en Vector2.zero.
        Assert.AreEqual(Vector2.zero,
                        (Vector2)ball.transform.position,
                        "La pelota debería volver al centro después de anotar");
    }

[Test]
    public void ScoreService_AddPoint_AccumulatesCorrectly()
    {
        // Arrange
        var service = new InMemoryScoreService();

        // Act
        service.AddPoint(true);   // P1++
        service.AddPoint(true);   // P1++
        service.AddPoint(false);  // P2++

        // Assert
        Assert.AreEqual(2, service.ScoreP1, "ScoreP1 debería ser 2 después de dos puntos de Player 1");
        Assert.AreEqual(1, service.ScoreP2, "ScoreP2 debería ser 1 después de un punto de Player 2");
    }

    // ─────────────────────────────────────────────────────────────
    // TEST 5 — InMemoryScoreService resetea scores a cero
    // ─────────────────────────────────────────────────────────────
    [Test]
    public void ScoreService_ResetScores_SetsScoresToZero()
    {
        // Arrange
        var service = new InMemoryScoreService();

        service.AddPoint(true);
        service.AddPoint(false);
        service.AddPoint(false);

        // Act
        service.ResetScores();

        // Assert
        Assert.AreEqual(0, service.ScoreP1, "ScoreP1 debería volver a 0 después de ResetScores()");
        Assert.AreEqual(0, service.ScoreP2, "ScoreP2 debería volver a 0 después de ResetScores()");
    }

}
