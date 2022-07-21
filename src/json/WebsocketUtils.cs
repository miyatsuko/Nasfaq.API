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
            try
            {
                JsonDocument jsonDocument = JsonDocument.Parse(content);
                return jsonDocument.RootElement[0].GetString();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message} for message {content}");
                File.AppendAllText("websocketerrors.txt", $"{e.Message}\nfor message: {content}\n\n\n\n");
                return null;
            }
        }

        public static IWebsocketData Read(string content)
        {
            return Read(content, out _, out _);
        }

        public static IWebsocketData Read(string content, out string eventName, out WebsocketEventType eventType)
        {
            JsonDocument jsonDocument = default;
            string websocketName = default;
            JsonElement jsonElement = default;
            try
            {
                jsonDocument = JsonDocument.Parse(content);
                websocketName = jsonDocument.RootElement[0].GetString();
                jsonElement = jsonDocument.RootElement[1];
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message} for message {content}");
                File.AppendAllText("websocketerrors.txt", $"{e.Message}\nfor message: {content}\n\n\n\n");
                eventName = null;
                eventType = WebsocketEventType.Public;
                return null;
            }


            eventName = websocketName;
            eventType = WebsocketEventType.Public;
            switch(websocketName)
            {
                case "dividendUpdate": eventType = WebsocketEventType.User; break;
                case "transactionUpdate": eventType = WebsocketEventType.User; break;
                case "autoTraderTimestampUpdate": eventType = WebsocketEventType.User; break;
                case "mutualFundRemoveUserRequest": eventType = WebsocketEventType.User; break;
                case "mutualFundUserFundsUpdate": eventType = WebsocketEventType.User; break;
                case "mutualFundUserOrderUpdate": eventType = WebsocketEventType.User; break;
                case "walletUpdate": eventType = WebsocketEventType.User; break;
                case "addChatBlock": eventType = WebsocketEventType.User; break;
                case "removeChatBlock": eventType = WebsocketEventType.User; break;
                case "addMessageDM": eventType = WebsocketEventType.User; break;
                case "mutualFundAutotraderTimestampUpdate": eventType = WebsocketEventType.Fund; break;
                case "mutualFundAutotraderUpdate": eventType = WebsocketEventType.Fund; break;
                case "mutualFundChatUpdate": eventType = WebsocketEventType.Fund; break;
                case "mutualFundJoinRequestsUpdate": eventType = WebsocketEventType.Fund; break;
            }

            try
            {
                switch(websocketName)
                {
                    /*missing 
                    itemsUpdate
                    */
                    case "coinPriceUpdate": return ReadStandard<WSCoinPriceUpdate>(jsonElement);
                    case "dividendUpdate": return ReadStandard<WSDividendUpdate>(jsonElement);
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
                    case "auctionFeed": return ReadStandard<WSAuctionFeed>(jsonElement);
                    case "addMessageGlobal": return ReadStandard<WSAddMessageGlobal>(jsonElement);
                    case "benchmarkUpdate": return ReadStandard<WSBenchmarkUpdate>(jsonElement);
                    case "benchmarkHistoryUpdate": return ReadStandard<WSBenchmarkHistoryUpdate>(jsonElement);
                    case "distributeBettingPool": return ReadStandard<WSDistributeBettingPool>(jsonElement);
                    case "userBetUpdate": return ReadStandard<WSUserBetUpdate>(jsonElement);
                    case "bettingPoolUpdate": return ReadStandard<WSBettingPoolUpdate>(jsonElement);
                    case "historyRefresh": return ReadStandard<WSHistoryRefresh>(jsonElement);
                    case "bettingPoolOpen": return ReadStandard<WSBettingPoolOpen>(jsonElement);
                    case "poolRefunded": return ReadStandard<WSPoolRefunded>(jsonElement);
                    case "bettingPoolDeleted": return ReadStandard<WSBettingPoolDeleted>(jsonElement);
                    case "bettingPoolArchived": return ReadStandard<WSBettingPoolArchived>(jsonElement);
                    case "benchmarkLeaderboardUpdate": return ReadStandard<WSBenchmarkLeaderboardUpdate>(jsonElement);
                    case "autoTraderTimestampUpdate": return ReadAutoTraderTimestampUpdate(jsonElement);
                    case "mutualFundAddPendingDissolve": return ReadStandard<WSMutualFundAddPendingDissolve>(jsonElement);
                    case "mutualFundBalanceUpdate": return ReadStandard<WSMutualFundBalanceUpdate>(jsonElement);
                    case "mutualFundBulletinUpdate": return ReadStandard<WSMutualFundBulletinUpdate>(jsonElement);
                    case "mutualFundChatUpdate": return ReadStandard<WSMutualFundChatUpdate>(jsonElement);
                    case "mutualFundDailyHistoryUpdate": return ReadStandard<WSMutualFundDailyHistoryUpdate>(jsonElement);
                    case "mutualFundJoinRequestsUpdate": return ReadStandard<WSMutualFundJoinRequestsUpdate>(jsonElement);
                    case "mutualFundMakePublicUpdate": return ReadStandard<WSMutualFundMakePublicUpdate>(jsonElement);
                    case "mutualFundMembersUpdate": return ReadStandard<WSMutualFundMembersUpdate>(jsonElement);
                    case "mutualFundOrderUpdate": return ReadStandard<WSMutualFundOrderUpdate>(jsonElement);
                    case "mutualFundPortfolioUpdate": return WSMutualFundPortfolioUpdate(jsonElement);
                    case "mutualFundRemoveUserRequest": return ReadStandard<WSMutualFundRemoveUserRequest>(jsonElement);
                    case "mutualFundResetOrdersUpdate": return new WSMutualFundResetOrdersUpdate();
                    case "mutualFundRunningHistoryUpdate": return ReadStandard<WSMutualFundRunningHistoryUpdate>(jsonElement);
                    case "mutualFundUserFundsUpdate": return ReadStandard<WSMutualFundUserFundsUpdate>(jsonElement);
                    case "mutualFundUserOrderUpdate": return ReadStandard<WSMutualFundUserOrderUpdate>(jsonElement);
                    case "mutualFundPayoutsUpdate": return ReadStandard<WSMutualFundPayoutsUpdate>(jsonElement);
                    case "mutualFundDissolved": return ReadMutualFundDissolved(jsonElement);
                    case "mutualFundAutotraderTimestampUpdate": return ReadStandard<WSMutualFundAutotraderTimestampUpdate>(jsonElement);
                    case "mutualFundAutotraderUpdate": return ReadStandard<WSMutualFundAutotraderUpdate>(jsonElement);
                    case "newMutualFund": return ReadStandard<WSNewMutualFund>(jsonElement);
                    case "mutualFundStatUpdate": return ReadStandard<WSMutualFundStatUpdate>(jsonElement);
                    case "userWorthUpdate": return ReadStandard<WSUserWorthUpdate>(jsonElement);
                    case "walletUpdate": return ReadStandard<WSWalletUpdate>(jsonElement);
                    case "addChatBlock": return ReadStandard<WSAddChatBlock>(jsonElement);
                    case "removeChatBlock": return ReadStandard<WSRemoveChatBlock>(jsonElement);
                    case "addMessageDM": return ReadStandard<WSAddMessageDM>(jsonElement);
                    case "newPoll": return ReadStandard<WSNewPoll>(jsonElement);
                    case "updatePollVotes": return ReadStandard<WSUpdatePollVotes>(jsonElement);
                    case "togglePoll": return ReadStandard<WSTogglePoll>(jsonElement);
                    case "deletePoll": return
                    ReadStandard<WSDeletePoll>(jsonElement);
                    case "malePotUpdate": return ReadMalePotUpdate(jsonElement);
                    case "noMalePotUpdate": return ReadNoMalePotUpdate(jsonElement);
                    case "maleSideUpdate": return ReadStandard<WSMaleSideUpdate>(jsonElement);
                }
                throw new KeyNotFoundException($"Websocket '{websocketName}' not handled, data: {jsonElement.ToString()}");
            }
            catch(KeyNotFoundException k)
            {
                Console.WriteLine(k.Message);
                File.AppendAllText("websocketerrors.txt", k.Message + "\n\n\n\n");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message} for message {content}");
                File.AppendAllText("websocketerrors.txt", $"{e.Message}\nfor message: {content}\n\n\n\n");
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

        private static WSMutualFundPortfolioUpdate WSMutualFundPortfolioUpdate(JsonElement element)
        {
            WSMutualFundPortfolioUpdate mutualFundPortfolioUpdate = new WSMutualFundPortfolioUpdate();
            mutualFundPortfolioUpdate.fund = element.GetProperty("fund").GetString();
            JsonElement update = element.GetProperty("tUpdate");
            {
                MutualFundPortfolioUpdate_Update mutualUpdate = new MutualFundPortfolioUpdate_Update();
                mutualUpdate.@event = update.GetProperty("event").GetString();
                mutualUpdate.transactions = new Transaction[update.GetProperty("transactions").GetArrayLength()];
                int i = 0;
                foreach(JsonElement transaction in update.GetProperty("transactions").EnumerateArray())
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
                    mutualUpdate.transactions[i] = trans;
                    i++;
                }
                JsonElement portfolio = update.GetProperty("portfolio");
                if(portfolio.ValueKind != JsonValueKind.Null)
                {
                    mutualUpdate.portfolio = JsonSerializer.Deserialize<Dictionary<string, MutualFundData_Fund_Portfolio>>(portfolio.GetRawText());
                }
                mutualFundPortfolioUpdate.tUpdate = mutualUpdate;
            }
            
            return mutualFundPortfolioUpdate;
        }

        private static WSAutoTraderTimestampUpdate ReadAutoTraderTimestampUpdate(JsonElement element)
        {
            return new WSAutoTraderTimestampUpdate() { timestamp = element.GetInt64()};
        }

        private static WSHistoryUpdate ReadHistoryUpdate(JsonElement element)
        {
            return new WSHistoryUpdate() { transactions = JsonSerializer.Deserialize<Transaction[]>(element.ToString())};
        }

        private static WSMutualFundDissolved ReadMutualFundDissolved(JsonElement element)
        {
            return new WSMutualFundDissolved() { fundId = element.ToString() };
        }

        private static WSStatisticsUpdate ReadStatisticsUpdate(JsonElement element)
        {
            return new WSStatisticsUpdate() { stats = GetStats.DeserializeStats(element, true)};
        }

        private static WSOshiboardUpdate ReadOshiboardUpdate(JsonElement element)
        {
            return new WSOshiboardUpdate() { oshiboard = JsonSerializer.Deserialize<Oshiboard>(element.ToString())};
        }

        private static WSMalePotUpdate ReadMalePotUpdate(JsonElement element)
        {
            return new WSMalePotUpdate() { value = element.GetDouble() };
        }

        private static WSNoMalePotUpdate ReadNoMalePotUpdate(JsonElement element)
        {
            return new WSNoMalePotUpdate() { value = element.GetDouble() };
        }

        private static WSRoomUpdate ReadRoomUpdate(JsonElement element)
        {
            return new WSRoomUpdate() { roomUpdate = JsonSerializer.Deserialize<WSRoomUpdate_Update[]>(element.ToString())};
        }

        private static WSMarketSwitch ReadMarketSwitch(JsonElement element)
        {
            return new WSMarketSwitch() { marketSwitch = element.GetBoolean()};
        }
    }

    public enum WebsocketEventType
    {
        Public,
        User,
        Fund
    }
}