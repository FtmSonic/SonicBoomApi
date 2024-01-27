# Sonic Boom Api

A project to use the power of Fantom Sonic to build game.

Don't lost time when you interact with blockchain on you game, with Sonic boom Api you can mint, transfer, send transaction with a response in less than 1 sec on Fantom blockchain.

You can retrieve data in less than 100 ms.

Sonic Boom's aim is to integrate blockchain into games requiring low ping and real-time interaction. You can't ask your user to wait between 2 and 30 seconds every time you make a transaction on the blockchain, you'd risk losing them.

## Sonic Boom Technology

Sonic boom is build with asp .net 8.0 and C#, is one of the more fastest backend on the market.

Sonic Boom use signalR to interact with the client, a powerfull technology who uses websocket to communicate with the client, it will be faster than a simple rest api to communicate between client and server.

Sonic Boom will use postgreSQL as its database, an open source database with advanced SQL support and fast queries even with millions of data records.

Sonic Boom interact with dedicated node in websocket (http in public testnet) to be fatest as possible.

With these all choices Sonic Boom will be one of the fastest Technology to use blockchain in the video games.

## Sonic Boom tools

Sonic Boom will come with dedicated client plugin for Unity.

Godot and Unreal will follow but you can use directly a signalR plugin to interact with Sonic Boom from any client.

For Javascript game or backend you can use the Microsoft signalR plugin from npm, 

Sonic boom will have is own smartcontract for Nft, Token, NFT Market and Swap Token, but you can use your own smartcontract if you want.

Sonic boom will integrate account abstraction in the futur, actually you can use wallet compatible with fantom network to connect or sign transaction.

## Sonic Boom Tarification

The tarification will be similar than any node provider.

You will have a free version who includes a number of transactions by day, you can choose between different package who depends of your queries usages, you can choose to have a dedicated server and node too, for these packages it's to you to pay transaction fee.

With account abstraction you keep same functionnalities than previous package but you need to fill your account with some token to paid transaction we will charge an extra 10% for these transactions, but don't worry fantom is one of the less expensive blockchain on the market.

## Schema

As an example of implementation, the game studio can choose to set up direct communication between the game and the Sonic Boom server, or to manage all communications via its own server. We generate 2 apis keys per project, one that can read and write, and the other that can only read data.
This second can be used, for example, directly by the game to retrieve items from users, or items on sale in the marketplace.

![App schema](https://github.com/youtpout/SecureSwap/blob/main/schema.png?raw=true)

# Local installation

### Scaffold Database

Update appsettings.json connectionsctring and create the database on postgres, after you can use ef to apply migration with Package Manager Console

dotnet tool install --global dotnet-ef

dotnet ef migrations add MigrationName --project SonicBoomOrm --startup-project SonicBoomApi

dotnet ef database update --project SonicBoomOrm --startup-project SonicBoomApi