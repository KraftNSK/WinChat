using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace WinChat
{
    static class Chat
    {
        private static bool isAuth;
        private static string tokenString;
        private static string login;
        private static string cookie;
        /// <summary>
        /// Индекс последнего полученного сообщения
        /// </summary>
        private static int lastMessageID;

        private static List<string> errors;

        public static string AppPath { get; set; }
        public static string Token { get { return tokenString; } }
        public static string Login { get { return login; } }

        public static bool IsAuth { get { return isAuth; } }

        static Chat()
        {
            tokenString = "";
            AppPath = "";
            isAuth = false;
            lastMessageID = -1;
            errors = new List<string>();
        }
        
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns>Строка с перечнем ошибок. Пустая строка - пользователь успешно создан</returns>
        public static string Register(string Login, string FirstName, string LastName, string Email, string Password)
        {
            string result, s="";
            HttpResponseMessage response;

            var registerModel = new
            {
                login = Login,
                firstname = FirstName,
                lastname = LastName,
                email = Email,
                password = Password
            };

            using (var client = new HttpClient())
            {
                try
                {
                    response = client.PostAsJsonAsync(AppPath + "/api/Registration", registerModel).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    s = "Register" + '\n';
                    s += DateTime.Now.ToShortTimeString() + '\n';
                    s += e.Message + '\n';
                    s += "Ошибка подключения" + '\n';
                    errors.Add(s);
                    return s;
                };

                //Пришла ошибка
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        List<ResponseError> respList = JsonConvert.DeserializeObject<List<ResponseError>>(result);
                        s = "";
                        foreach (ResponseError str in respList)
                        {
                            s += str.Text + '\n';
                        };
                        errors.Add(s);
                        return s;
                    }
                    catch (Exception e)
                    {
                        s = "Register" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации" + '\n';
                        errors.Add(s);
                        return s;
                    };
                }
                else
                {
                    //Пользователь создан
                    return "";
                }
            }
        }

        /// <summary>
        /// Аутентификация существующего пользователя
        /// </summary>
        public static string Auth(string Login, string Password)
        {
            string result, s="";
            HttpResponseMessage response;

            var enterModel = new
            {
                login = Login,
                password = Password
            };

            using (var client = new HttpClient())
            {
                try
                {
                    response = client.PostAsJsonAsync(AppPath + "/api/Account", enterModel).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    s = "Auth" + '\n';
                    s += DateTime.Now.ToShortTimeString() + '\n';
                    s += e.Message + '\n';
                    s += "Ошибка подключения" + '\n';
                    errors.Add(s);
                    return s;
                };
                

                //Пришла ошибка
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        List<ResponseError> respList = JsonConvert.DeserializeObject<List<ResponseError>>(result);
                        s = "";
                        foreach (ResponseError str in respList)
                        {
                            s += str.Text + '\n';
                        }
                        errors.Add(s);
                        return s;
                    }
                    catch (Exception e)
                    {
                        s = "Auth" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации списка ошибок" + '\n';
                        errors.Add(s);
                        return s;
                    };
                }
                else
                {
                    //Авторизован
                    try
                    {
                        TokenMessage tm = JsonConvert.DeserializeObject<TokenMessage>(result);
                        tokenString = tm.Token;
                        login = tm.Login;
                        cookie = tm.Cookie;
                        isAuth = true;

                        return "";
                    }
                    catch (Exception e)
                    {
                        s = "Auth" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации корректного ответа" + '\n';
                        errors.Add(s);
                        return s;
                    };
                }
            }
        }

        /// <summary>
        /// Запрос новых сообщений с сервера
        /// </summary>
        /// <returns></returns>
        public static List<ServerMessage> GetNewMessages()
        {
            if (!isAuth) return null;

            string result, s = "";
            HttpResponseMessage response;

            var requestModel = new
            {
                LastMessageID = lastMessageID,
                token = tokenString
            };

            using (var client = new HttpClient())
            {
                try
                {
                    response = client.PostAsJsonAsync(AppPath + "/api/Chat", requestModel).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    s = "GetNewMessages" + '\n';
                    s += DateTime.Now.ToShortTimeString() + '\n';
                    s += e.Message + '\n';
                    s += "Ошибка подключения" + '\n';
                    errors.Add(s);
                    return null;
                };

                //Пришла ошибка
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        List<ResponseError> respList = JsonConvert.DeserializeObject<List<ResponseError>>(result);
                        s = "";
                        foreach (ResponseError str in respList)
                        {
                            s += str.Text + '\n';
                        }
                        errors.Add(s);
                        return null;
                    }
                    catch (Exception e)
                    {
                        s = "GetNewMessages" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации списка ошибок" + '\n';
                        errors.Add(s);
                        return null;
                    };
                }
                else
                {
                    try
                    {
                        List<ServerMessage> tm = JsonConvert.DeserializeObject<List<ServerMessage>>(result);
                        if (tm != null)
                            if (tm.Count > 0)
                            {
                                if(lastMessageID < tm[tm.Count - 1].Id) lastMessageID = tm[tm.Count - 1].Id;
                                return tm;
                            }
                        return null;
                    }
                    catch (Exception e)
                    {
                        s = "GetNewMessages" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации корректного ответа" + '\n';
                        errors.Add(s);
                        return null;
                    };
                }
            }
        }

        /// <summary>
        /// Отправка сообщения на сервер
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static List<ServerMessage> SendMessage(string msg)
        {
            if (!isAuth) return null;

            string result, s = "";
            HttpResponseMessage response;

            var requestModel = new
            {
                LastMessageID = lastMessageID,
                token = tokenString,
                text = msg,
                dt = DateTime.Now
            };

            using (var client = new HttpClient())
            {
                try
                {
                    response = client.PutAsJsonAsync(AppPath + "/api/Chat", requestModel).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    s = "Auth" + '\n';
                    s += DateTime.Now.ToShortTimeString() + '\n';
                    s += e.Message + '\n';
                    s += "Ошибка подключения" + '\n';
                    errors.Add(s);
                    return null;
                };

                //Пришла ошибка
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        List<ResponseError> respList = JsonConvert.DeserializeObject<List<ResponseError>>(result);
                        s = "";
                        foreach (ResponseError str in respList)
                        {
                            s += str.Text + '\n';
                        }
                        errors.Add(s);
                        return null;
                    }
                    catch (Exception e)
                    {
                        s = "SendMessage" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации списка ошибок" + '\n';
                        errors.Add(s);
                        return null;
                    };
                }
                else
                {
                    try
                    {
                        List<ServerMessage> tm = JsonConvert.DeserializeObject<List<ServerMessage>>(result);
                        if (tm != null)
                            if (tm.Count > 0)
                            {
                                if(lastMessageID < tm[tm.Count - 1].Id) lastMessageID = tm[tm.Count - 1].Id;
                                return tm;
                            }
                        return null;
                    }
                    catch (Exception e)
                    {
                        s = "SendMessage" + '\n';
                        s += DateTime.Now.ToShortTimeString() + '\n';
                        s += response.ReasonPhrase + '\n';
                        s += e.Message + '\n';
                        s += "Ошибка десериализации корректного ответа" + '\n';
                        errors.Add(s);
                        return null;
                    };
                }
            }
        } 

        /// <summary>
        /// Отмена аутентификаыии
        /// </summary>
        public static void Exit()
        {
            isAuth = false;
            login = "";
            tokenString = "";
            cookie = "";
        }
        
    }
}
