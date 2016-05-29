using Newtonsoft.Json;

namespace QuikSharp.DataStructures
{

	public enum FuturesLimitType
	{
        /// <summary>
        /// Денежные средства
        /// </summary>
		Money = 0,
        /// <summary>
        /// Залоговые денежные средства
        /// </summary>
		Bail = 1,
        /// <summary>
        /// Всего
        /// </summary>
		Total = 2,
        /// <summary>
        /// Клиринговые рубли
        /// </summary>
		Clearing = 3,
        /// <summary>
        /// Клиринговые залоговые рубли
        /// </summary>
		ClearingBail = 4,
        /// <summary>
        /// Лимит открытых позиций на спот-рынке
        /// </summary>
		Limit = 5,
	}

    /// <summary>
    /// Строка таблицы "Лимиты по фьючерсам" (Lua: futures_client_limits)
    /// </summary>
    public class FuturesLimit
    {
        /// <summary>Идентификатор фирмы</summary>
        [JsonProperty("firmid")]
        public string FirmId;

        /// <summary>Торговый счет</summary>
        [JsonProperty("trdaccid")]
        public string TrdAccId;

        /// <summary>
        /// Тип лимита. Возможные значения: 
        ///«0» – «Денежные средства», 
        ///«1» – «Залоговые денежные средства», 
        ///«2» – «Всего», 
        ///«3» – «Клиринговые рубли», 
        ///«4» – «Клиринговые залоговые рубли», 
        ///«5» – «Лимит открытых позиций на спот-рынке»
        ///</summary>
        [JsonProperty("limit_type")]
        public int LimitTypeId
        {
            get
            {
                return (int)LimitType;
            }
            set
            {
                LimitType = (FuturesLimitType)value;
            }
        }

        [JsonIgnore]
        public FuturesLimitType LimitType;

        /// <summary>Коэффициент ликвидности</summary>
        [JsonProperty("liquidity_coef")]
        public double LiquidityCoef;

        /// <summary>Предыдущий лимит открытых позиций на спот-рынке»</summary>
        [JsonProperty("cbp_prev_limit")]
        public double PrevLimit;

        /// <summary>Лимит открытых позиций</summary>
        [JsonProperty("cbplimit")]
        public double Limit;

        /// <summary>Текущие чистые позиции</summary>
        [JsonProperty("cbplused")]
        public double Used;

        /// <summary>Плановые чистые позиции</summary>
        [JsonProperty("cbplplanned")]
        public double Planned;

        /// <summary>Вариационная маржа</summary>
        [JsonProperty("varmargin")]
        public double VarMargin;

        /// <summary>Накопленный доход</summary>
        [JsonProperty("accruedint")]
        public double AccruedIncome;

        /// <summary>Текущие чистые позиции (под заявки)</summary>
        [JsonProperty("cbplused_for_orders")]
        public double UsedForOrders;

        /// <summary>Текущие чистые позиции (под открытые позиции)</summary>
        [JsonProperty("cbplused_for_positions")]
        public double UsedForPositions;

        /// <summary>Премия по опционам</summary>
        [JsonProperty("options_premium")]
        public double OptionsPremium;

        /// <summary>Биржевые сборы</summary>
        [JsonProperty("ts_comission")]
        public double Comission;

        /// <summary>Коэффициент клиентского гарантийного обеспечения</summary>
        [JsonProperty("kgo")]
        public double InitialMarginCoef;

        /// <summary>Валюта, в которой транслируется ограничение</summary>
        [JsonProperty("currcode")]
        public string Currency;

        /// <summary>
        /// Реально начисленная в ходе клиринга вариационная маржа. Отображается с точностью до 2 двух знаков. При этом, в поле «varmargin» транслируется вариационная маржа, рассчитанная с учетом установленных границ изменения цены
        /// </summary>
        [JsonProperty("real_varmargin")]
        public double RealVarMargin;
    }
}
