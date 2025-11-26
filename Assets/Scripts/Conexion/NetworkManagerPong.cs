using Mirror;
using UnityEngine;

public class NetworkManagerPong : NetworkManager
{
    public GameObject playerBluePrefab;   // Player 1
    public GameObject playerOrangePrefab; // Player 2

    public Transform leftSpawn;   // Spawn Player Azul
    public Transform rightSpawn;  // Spawn Player Naranja

    public GameObject ballPrefab;
    GameObject ballInstance;


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // SI YA TIENE PLAYER, NO CREAR OTRO
        if (conn.identity != null)
        {
            return;
        }

        GameObject prefabToSpawn;
        Transform spawnPos;

        // Primer jugador → azul
        if (numPlayers == 0)
        {
            
            prefabToSpawn = playerBluePrefab;
            spawnPos = leftSpawn;
        }
        else
        {
            // Segundo jugador → naranja
            
            prefabToSpawn = playerOrangePrefab;
            spawnPos = rightSpawn;
        }

        GameObject player = Instantiate(prefabToSpawn, spawnPos.position, spawnPos.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // Instanciar pelota cuando haya 2 jugadores
        if (numPlayers == 2)
        {
            ballInstance = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            NetworkServer.Spawn(ballInstance);
        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // Si alguien se sale → destruir pelota
        if (ballInstance != null)
        {
            NetworkServer.Destroy(ballInstance);
            ballInstance = null;
        }

        base.OnServerDisconnect(conn);
    }
}
