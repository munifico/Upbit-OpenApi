using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 업비트_자동맴
{
    class upbit_info
    {
        public string ticker_url = "https://api.upbit.com/v1/ticker";
        public string account_url = "https://api.upbit.com/v1/accounts";
        public string order_url = "https://api.upbit.com/v1/orders";
        public string ordercehck_url = "https://api.upbit.com/v1/order";
        public string orderinfo_url = "https://api.upbit.com/v1/orders/chance";
        public string marketlist_url = "https://api.upbit.com/v1/market/all";
        public string chance_url = "https://api.upbit.com/v1/orders/chance";


        public string Access_Key = "";
        public string Secret_Key = "";

        public string uuid(){return  Guid.NewGuid().ToString();}
        public string Order_Delete(string uuids)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            StringBuilder builder = new StringBuilder();
            parameters.Add("uuid", uuids);


            foreach (KeyValuePair<string, string> pair in parameters)
            {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            string queryString = builder.ToString().TrimEnd('&');
            var data = UTF8Encoding.UTF8.GetBytes(queryString);
            SHA512 sha512 = SHA512.Create();
            byte[] queryHashByteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            string queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();

            var payload = new JwtPayload
            {
                { "access_key",  Access_Key  },
                { "nonce", uuid()},
                { "query_hash", queryHash },
                { "query_hash_alg", "SHA512" }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); //JWT 라이브러리 이용하여 JWT 토큰을 만듭니다.
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, Secret_Key);
            var authorize_token = string.Format("Bearer {0}", token);

            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ordercehck_url + "?" + queryString); //요청 과정
                request.Method = "DELETE";
                request.Headers.Add(string.Format("Authorization:{0}", authorize_token));
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                /*
                JArray jsonArray = JArray.Parse(strResult);
                foreach (var item in jsonArray.Children())
                {
                    ListViewItem lv = new ListViewItem(item["currency"].ToString());
                    lv.SubItems.Add(item["balance"].ToString());
                    lv.SubItems.Add(item["locked"].ToString());
                    lv.SubItems.Add(item["avg_buy_price"].ToString());
                    //obj.Items.Add(lv);
                }
                */
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;

        }
        public string Order_Check(string uuids)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            StringBuilder builder = new StringBuilder();
            parameters.Add("uuid", uuids);


            foreach (KeyValuePair<string, string> pair in parameters)
            {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            string queryString = builder.ToString().TrimEnd('&');
            var data = UTF8Encoding.UTF8.GetBytes(queryString);
            SHA512 sha512 = SHA512.Create();
            byte[] queryHashByteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            string queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();

            var payload = new JwtPayload
            {
                { "access_key",  Access_Key  },
                { "nonce", uuid()},
                { "query_hash", queryHash },
                { "query_hash_alg", "SHA512" }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); //JWT 라이브러리 이용하여 JWT 토큰을 만듭니다.
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, Secret_Key);
            var authorize_token = string.Format("Bearer {0}", token);

            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ordercehck_url + "?" + queryString); //요청 과정
                request.Method = "GET";
                request.Headers.Add(string.Format("Authorization:{0}", authorize_token));
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;

        }
        public string CoinList(ComboBox obj)
        {
            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(marketlist_url + "?isDetails=false"); //요청 과정
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                JArray jsonArray = JArray.Parse(strResult);
                foreach (var item in jsonArray.Children())
                {
                    //시장정보와 코인 한글이름을 저장한다
                    if (item["market"].ToString().Split('-')[0] == "KRW")
                        obj.Items.Add(item["korean_name"].ToString() + ":" + item["market"].ToString());
                }
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;
        }

        public string AccountInquiry(ListView obj)//계좌 조회
        {
            var payload = new Dictionary<string, object>
            {
                { "access_key", Access_Key  },
                { "nonce", uuid()},
                { "query_hash_alg", "SHA512" }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); //JWT 라이브러리 이용하여 JWT 토큰을 만듭니다.
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, Secret_Key);
            var authorize_token = string.Format("Bearer {0}", token);

            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(account_url); //요청 과정
                request.Method = "GET";

                request.Headers.Add(string.Format("Authorization:{0}", authorize_token));
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                JArray jsonArray = JArray.Parse(strResult);
                foreach (var item in jsonArray.Children())
                {
                    ListViewItem lv = new ListViewItem(item["currency"].ToString());
                    lv.SubItems.Add(item["balance"].ToString());
                    lv.SubItems.Add(item["locked"].ToString());
                    lv.SubItems.Add(item["avg_buy_price"].ToString());
                    obj.Items.Add(lv);
                }
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;
        }
        public string OrderInfo(string market)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            StringBuilder builder = new StringBuilder();
            parameters.Add("market", market);


            foreach (KeyValuePair<string, string> pair in parameters)
            {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            string queryString = builder.ToString().TrimEnd('&');
            var data = UTF8Encoding.UTF8.GetBytes(queryString);
            SHA512 sha512 = SHA512.Create();
            byte[] queryHashByteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            string queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();

            var payload = new JwtPayload
            {
                { "access_key",  Access_Key  },
                { "nonce", uuid()},
                { "query_hash", queryHash },
                { "query_hash_alg", "SHA512" }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); //JWT 라이브러리 이용하여 JWT 토큰을 만듭니다.
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, Secret_Key);
            var authorize_token = string.Format("Bearer {0}", token);

            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(chance_url + "?" + queryString); //요청 과정
                request.Method = "GET";
                request.Headers.Add(string.Format("Authorization:{0}", authorize_token));
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                JObject jsonObject = JObject.Parse(strResult);
                /*
                strResult += jsonObject["bid_fee"].ToString();//매수 수수료 비율
                strResult += jsonObject["bid_fee"].ToString();//매도수수료 비율
                
                strResult += jsonObject["bid_fee"].ToString();
                strResult += jsonObject["bid_fee"].ToString();
                strResult += jsonObject["bid_fee"].ToString();
                strResult += jsonObject["bid_fee"].ToString();
                */

                //매도가능 수량구하기
                JObject ob_ask = JObject.Parse(jsonObject["ask_account"].ToString());
                strResult = ob_ask["balance"].ToString();
                

                /*
                foreach (var item in jsonArray.Children())
                {
                    ListViewItem lv = new ListViewItem(item["currency"].ToString());
                    lv.SubItems.Add(item["balance"].ToString());
                    lv.SubItems.Add(item["locked"].ToString());
                    lv.SubItems.Add(item["avg_buy_price"].ToString());
                }*/
                //strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;
        }
        public string OrderCoin(string market, string bid, string volum, string price, string ord_type)
        {
            //코인을 매수 / 매도하는 함수
            Dictionary<string, string> parameters = new Dictionary<string, string>();
             StringBuilder builder = new StringBuilder();
            parameters.Add("market", market);
            parameters.Add("side", bid);//bid = 매수 ask = 매도
            if(ord_type != "price")
                parameters.Add("volume", volum);
            if (ord_type != "market")
                parameters.Add("price", price);
            parameters.Add("ord_type", ord_type);//limit = 지정가 price = 시장가주문매수 market = 시장가주문매도


            foreach (KeyValuePair<string, string> pair in parameters)
            {
                builder.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
            }
            string queryString = builder.ToString().TrimEnd('&');
            var data = UTF8Encoding.UTF8.GetBytes(queryString);
            SHA512 sha512 = SHA512.Create();
            byte[] queryHashByteArray = sha512.ComputeHash(Encoding.UTF8.GetBytes(queryString));
            string queryHash = BitConverter.ToString(queryHashByteArray).Replace("-", "").ToLower();

            var payload = new JwtPayload
            {
                { "access_key",  Access_Key  },
                { "nonce", uuid()},
                { "query_hash", queryHash },
                { "query_hash_alg", "SHA512" }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); //JWT 라이브러리 이용하여 JWT 토큰을 만듭니다.
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, Secret_Key);
            var authorize_token = string.Format("Bearer {0}", token);

            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(order_url + "?" + queryString); //요청 과정
                request.Method = "POST";
                request.Headers.Add(string.Format("Authorization:{0}", authorize_token));
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;
        }



        public string ticker(string market)
        {
            //실시간으로 데이터를 받는부분에 퍼센트지를 구하기위해 각 코인을 시작가를 받아오는부분.
            string str = "";
            string strResult;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ticker_url + "?markets=" + market); //요청 과정
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                JArray jsonArray = JArray.Parse(strResult);
                
                foreach (var item in jsonArray.Children())
                {
                    //시장정보와 코인 한글이름을 저장한다
                    str += item["opening_price"].ToString() + ",";
                    str += item["high_price"].ToString() + ",";
                    str += item["low_price"].ToString();
                }
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return str;

        }
    }
}
