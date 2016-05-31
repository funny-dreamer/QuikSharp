using Newtonsoft.Json;

namespace QuikSharp.DataStructures
{
    /// <summary>
    /// Строка таблицы "Лимиты по денежным средствам" (Lua: money_limits)
    /// Примечание: класс <see cref="MoneyLimitEx"/> состоит из полей класса <see cref="MoneyLimit"/> и данного класса.
    /// </summary>
    public class MoneyLimit2
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        public string currcode;
        /// <summary>
        /// Тэг расчетов
        /// </summary>
        public string tag;
        /// <summary>
        /// Идентификатор фирмы
        /// </summary>
        public string firmid;
        /// <summary>
        /// Код клиента
        /// </summary>
        public string client_code;
        /// <summary>
        /// Входящий остаток по деньгам
        /// </summary>
        public double openbal;
        /// <summary>
        /// Входящий лимит по деньгам
        /// </summary>
        public double openlimit;
        /// <summary>
        /// Текущий остаток по деньгам
        /// </summary>
        public double currentbal;
        /// <summary>
        /// Текущий лимит по деньгам
        /// </summary>
        public double currentlimit;
        /// <summary>
        /// Заблокированное количество
        /// </summary>
        public double locked;
        /// <summary>
        /// Стоимость активов в заявках на покупку немаржинальных бумаг
        /// </summary>
        public double locked_value_coef;
        /// <summary>
        /// Стоимость активов в заявках на покупку маржинальных бумаг
        /// </summary>
        public double locked_margin_value;
        /// <summary>
        /// Плечо
        /// </summary>
        public double leverage;
        /// <summary>
        /// Тип лимита
        /// </summary>
        [JsonProperty("limit_kind")]
        public LimitKind LimitKind;
    }
}
