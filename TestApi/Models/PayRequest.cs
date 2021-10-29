using System.Text.RegularExpressions;
using System.Web;

namespace TestApi
{
    class PayRequest
    {
        private string _key;
        private string _orderId;
        private string _amount;
        private string _payInfo;
        private Regex regex;
        private MatchCollection match;

        public PayRequest SetKey(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
                _key = $"Key={key}&";
            return this;
        }
        public PayRequest SetOrderId(string orderId)
        {
            regex = new Regex("[0-9A-Za-z-]{1,50}");
            match = regex.Matches(orderId);
            if (match.Count > 0)
                _orderId = $"OrderId={ match[0]}&";
            return this;
        }
        public PayRequest SetAmount(int amount)
        {
            regex = new Regex("^[0-9]{0,2147483647}");
            match = regex.Matches(amount.ToString());
            if (match.Count > 0)
                _amount = $"Amount={match[0]}&";
            return this;
        }
        public PayRequest SetPayInfo(string payInfo)
        {
            if (!string.IsNullOrWhiteSpace(payInfo))
                _payInfo = payInfo;
            return this;
        }
        public string Create()
        {
            return _key + _amount + _orderId + _payInfo;
        }
    }
}
