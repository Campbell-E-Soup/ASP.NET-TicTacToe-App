using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace TicTacToe.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string k, T obj)
        {
            session.SetString(k,JsonConvert.SerializeObject(obj));
        }

        public static T? GetObject<T>(this ISession session, string k)
        {
            var json = session.GetString(k);
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
