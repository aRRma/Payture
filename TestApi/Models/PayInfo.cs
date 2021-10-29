using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TestApi
{
    class PayInfo
    {
        private string _pan;
        private string _eMonth;
        private string _eYear;
        private string _orderId;
        private string _amount;
        private string _secureCode;
        private string _cardHolder;
        private Regex regex;
        private MatchCollection match;

        public PayInfo SetPan(string pan)
        {
            regex = new Regex("^[0-9]{13,19}");
            match = regex.Matches(pan);
            if (match.Count > 0)
                _pan = WebUtility.UrlEncode($"PAN={match[0]};");
            return this;
        }
        public PayInfo SetEMonth(int month)
        {
            if (month is > 0 and < 13)
                _eMonth = WebUtility.UrlEncode($"EMonth={month};");
            return this;
        }
        public PayInfo SetEYear(int year)
        {
            regex = new Regex("[0-9]{2}$");
            match = regex.Matches(year.ToString());
            if (match.Count > 0)
                _eYear = WebUtility.UrlEncode($"EYear={match[0]};");
            return this;
        }
        public PayInfo SetOrderId(string orderId)
        {
            regex = new Regex("[0-9A-Za-z-]{1,50}");
            match = regex.Matches(orderId);
            if (match.Count > 0)
                _orderId = WebUtility.UrlEncode($"OrderId={match[0]};");
            return this;
        }
        public PayInfo SetAmount(int amount)
        {
            regex = new Regex("^[0-9]{0,2147483647}");
            match = regex.Matches(amount.ToString());
            if (match.Count > 0)
                _amount = WebUtility.UrlEncode($"Amount={match[0]}");
            return this;
        }
        public PayInfo SetSecureCode(int secureCode)
        {
            regex = new Regex("^[0-9]{3,4}");
            match = regex.Matches(secureCode.ToString());
            if (match.Count > 0)
                _secureCode = WebUtility.UrlEncode($"SecureCode={match[0]};");
            return this;
        }
        public PayInfo SetCardHolder(string cardHolder)
        {
            regex = new Regex("[A-z]{1,}");
            match = regex.Matches(cardHolder);
            if (match.Count > 1)
                _cardHolder = WebUtility.UrlEncode($"CardHolder={match[0]} {match[1]};");
            return this;
        }
        public string Create()
        {
            return "PayInfo=" + _pan + _eMonth + _eYear + _cardHolder + _secureCode + _orderId + _amount;
        }
    }
}
