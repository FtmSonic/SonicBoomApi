# Sonic Boom Api

A project to use the power of Fantom Sonic to build game.

Don't lose time when you interact with blockchain on your game, with Sonic boom Api you can mint, transfer, send transaction with a response in less than 1 sec on Fantom blockchain.

You can retrieve data in less than 100 ms.

Sonic Boom's aim is to integrate blockchain into games requiring low ping and real-time interaction. You can't ask your user to wait between 2 and 30 seconds every time you make a transaction on the blockchain, you'd risk losing them.

## Sonic Boom Technology

Sonic boom is built with asp .net 8.0 and C#, is one of the fastest backend on the market.

Sonic Boom uses signalR to interact with the client, a powerful technology that uses websocket to communicate with the client, it will be faster than a simple rest api to communicate between client and server.

Sonic Boom will use postgreSQL as its database, an open source database with advanced SQL support and fast queries even with millions of data records.

Sonic Boom interacts with dedicated node in websocket (http in public testnet) to be the fastest as possible.

With these all choices Sonic Boom will be one of the fastest Technology to use blockchain in the video games.

## Sonic Boom tools

Sonic Boom will come with dedicated client plugin for Unity. 

Godot, Unreal, Javascript will follow but you can use directly a signalR plugin to interact with Sonic Boom from any client.

The goal is to focus on different backend technology like .net, go, nodejs ... to have a plugin easy to use to interact with sonic boom.

Sonic boom will have its own smartcontract for Nft, Token, NFT Market and Swap Token, but you can use your own smartcontract if you want.

Sonic boom will integrate account abstraction or custodial wallet in the future, but for now you can use wallet compatible with fantom network to connect or sign transaction.

## Sonic Boom Tarification

The tarification will be similar as any node provider.

You will have a free version which includes a number of transactions by day, you can choose between different packages that depends on your queries usages, you can choose to have a dedicated server and node too, for these packages it's up to you to pay transaction fee.

You can have a relayer, you keep the same functionalities as in previous package but you need to fill the relayer account with some fantom. For each transaction we will charge an extra 10%, but don't worry fantom is one of the less expensive blockchain on the market.

## Schema

As an example of implementation, the game studio can choose to set up direct communication between the game and the Sonic Boom server, or to manage all communications via its own server. We generate 2 apis keys per project, one that can read and write, and the other that can only read data.
This second can be used, for example, directly by the game to retrieve items from users, or items on sale in the marketplace.

![App schema](https://github.com/FtmSonic/SonicBoomApi/blob/main/schema.png?raw=true)

# Local installation

### Scaffold Database

Update appsettings.json connectionsctring and create the database on postgres, after you can use ef to apply migration with Package Manager Console

dotnet tool install --global dotnet-ef

dotnet ef migrations add MigrationName --project SonicBoomOrm --startup-project SonicBoomApi

dotnet ef database update --project SonicBoomOrm --startup-project SonicBoomApi
