using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;

namespace Nasfaq.JSON
{
    public static class WebsocketReader
    {
        public static string ReadEventName(string content)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            return jsonDocument.RootElement[0].GetString();
        }

        public static IWebsocketData Read(string content)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            string websocketName = jsonDocument.RootElement[0].GetString();
            JsonElement jsonElement = jsonDocument.RootElement[1];

            try
            {
                switch(websocketName)
                {
                    case "coinPriceUpdate": return ReadStandard<WSCoinPriceUpdate>(jsonElement);
                    case "dividendUpdate": return ReadDividendUpdate(jsonElement);
                    case "floorUpdate": return ReadStandard<WSFloorUpdate>(jsonElement);
                    case "gachaUpdate": return ReadStandard<WSGachaUpdate>(jsonElement);
                    case "brokerFeeUpdate": return ReadStandard<WSBrokerFeeUpdate>(jsonElement);
                    case "historyUpdate": return ReadHistoryUpdate(jsonElement);
                    case "leaderboardUpdate": return ReadStandard<WSLeaderboardUpdate>(jsonElement);
                    case "oshiboardUpdate": return ReadOshiboardUpdate(jsonElement);
                    case "todayPricesUpdate": return ReadStandard<WSTodayPricesUpdate>(jsonElement);
                    case "transactionUpdate": return ReadTransactionUpdate(jsonElement);
                    case "marketSwitch": return ReadMarketSwitch(jsonElement);
                    case "superchatUpdate": return ReadStandard<WSSuperChatUpdate>(jsonElement);
                    case "statisticsUpdate": return ReadStatisticsUpdate(jsonElement);
                    case "coinHistoryUpdate": return ReadStandard<WSCoinHistoryUpdate>(jsonElement);
                    case "creditsUpdate": return ReadStandard<WSCreditsUpdate>(jsonElement);
                    case "auctionUpdate": return ReadStandard<WSAuctionUpdate>(jsonElement);
                }
                throw new KeyNotFoundException($"Websocket '{websocketName}' not handled, data: {jsonElement.ToString()}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.AppendAllText("websocketerrors.txt", e.Message + "\n\n\n\n");
            }
            return null;
        }

        private static T ReadStandard<T>(JsonElement element) where T : IWebsocketData
        {
            return JsonSerializer.Deserialize<T>(element.ToString());
        }

        private static WSTransactionUpdate ReadTransactionUpdate(JsonElement element)
        {
            WSTransactionUpdate transtionUpdate = new WSTransactionUpdate();
            transtionUpdate.@event = element.GetProperty("event").GetString();
            transtionUpdate.transactions = new Transaction[element.GetProperty("transactions").GetArrayLength()];
            int i = 0;
            foreach(JsonElement transaction in element.GetProperty("transactions").EnumerateArray())
            {
                Transaction trans = new Transaction();
                trans.coin = transaction.GetProperty("coin").GetString();
                trans.type = transaction.GetProperty("type").GetInt32();
                trans.userid = transaction.GetProperty("userid").GetString();
                trans.quantity = transaction.GetProperty("quantity").GetInt32();
                trans.timestamp = transaction.GetProperty("timestamp").GetInt64();
                trans.completed = transaction.GetProperty("completed").GetBoolean();
                JsonElement price = transaction.GetProperty("price");
                if(price.ValueKind != JsonValueKind.Null)
                {
                    trans.price = price.GetDouble();
                }
                transtionUpdate.transactions[i] = trans;
                i++;
            }
            JsonElement wallet = element.GetProperty("wallet");
            if(wallet.ValueKind != JsonValueKind.Null)
            {
                transtionUpdate.wallet = JsonSerializer.Deserialize<UserWallet>(wallet.GetRawText());
            }
            return transtionUpdate;
        }

        private static WSDividendUpdate ReadDividendUpdate(JsonElement element)
        {
            return new WSDividendUpdate() { wallet = JsonSerializer.Deserialize<UserWallet>(element.ToString())};
        }

        private static WSHistoryUpdate ReadHistoryUpdate(JsonElement element)
        {
            return new WSHistoryUpdate() { transactions = JsonSerializer.Deserialize<Transaction[]>(element.ToString())};
        }

        private static WSStatisticsUpdate ReadStatisticsUpdate(JsonElement element)
        {
            return new WSStatisticsUpdate() { stats = JsonSerializer.Deserialize<Dictionary<string, Stats> >(element.ToString())};
        }

        private static WSOshiboardUpdate ReadOshiboardUpdate(JsonElement element)
        {
            return new WSOshiboardUpdate() { oshiboard = JsonSerializer.Deserialize<Oshiboard>(element.ToString())};
        }

        private static WSRoomUpdate ReadRoomUpdate(JsonElement element)
        {
            return new WSRoomUpdate() { roomUpdate = JsonSerializer.Deserialize<WSRoomUpdate_Update[]>(element.ToString())};
        }

        private static WSMarketSwitch ReadMarketSwitch(JsonElement element)
        {
            return new WSMarketSwitch() { marketSwitch = JsonSerializer.Deserialize<bool>(element.ToString())};
        }
    }
}