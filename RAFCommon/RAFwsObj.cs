
namespace RAFCommon
{
    using System.Xml.Serialization;


    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class RAFwsObj
    {

        private Request requestField;

        private Response responseField;

        /// <remarks/>
        public Request Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        public Response Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Request
    {

        private Parameters parametersField;

        /// <remarks/>
        public Parameters Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Parameters
    {

        private string prmIdCustomerField;

        private string prmAssetTypeIdField;

        private string prmAssetIdField;

        private string prmTransactionTypeField;

        private string prmChannelField;

        private string prmLanguageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", IsNullable = true)]
        public string prmIdCustomer
        {
            get
            {
                return this.prmIdCustomerField;
            }
            set
            {
                this.prmIdCustomerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string prmAssetTypeId
        {
            get
            {
                return this.prmAssetTypeIdField;
            }
            set
            {
                this.prmAssetTypeIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string prmAssetId
        {
            get
            {
                return this.prmAssetIdField;
            }
            set
            {
                this.prmAssetIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", IsNullable = true)]
        public string prmTransactionType
        {
            get
            {
                return this.prmTransactionTypeField;
            }
            set
            {
                this.prmTransactionTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", IsNullable = true)]
        public string prmChannel
        {
            get
            {
                return this.prmChannelField;
            }
            set
            {
                this.prmChannelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string prmLanguage
        {
            get
            {
                return this.prmLanguageField;
            }
            set
            {
                this.prmLanguageField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Response
    {

        private Status statusField;

        private Asset assetField;

        private string responseIDField;

        /// <remarks/>
        public Status Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public Asset Asset
        {
            get
            {
                return this.assetField;
            }
            set
            {
                this.assetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ResponseID
        {
            get
            {
                return this.responseIDField;
            }
            set
            {
                this.responseIDField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Status
    {

        private bool successField;

        private string errorCodeField;

        private string errorMessageField;

        /// <remarks/>
        public bool Success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        public string ErrorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Asset
    {

        private Channel[] validChannelsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Channel", IsNullable = false)]
        public Channel[] ValidChannels
        {
            get
            {
                return this.validChannelsField;
            }
            set
            {
                this.validChannelsField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Channel
    {

        private string channelIDField;

        private string channelNameField;

        private string[] allowedTransactionsField;

        private Rules rulesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ChannelID
        {
            get
            {
                return this.channelIDField;
            }
            set
            {
                this.channelIDField = value;
            }
        }

        /// <remarks/>
        public string ChannelName
        {
            get
            {
                return this.channelNameField;
            }
            set
            {
                this.channelNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AllowedTransactionID", DataType = "integer", IsNullable = false)]
        public string[] AllowedTransactions
        {
            get
            {
                return this.allowedTransactionsField;
            }
            set
            {
                this.allowedTransactionsField = value;
            }
        }

        /// <remarks/>
        public Rules Rules
        {
            get
            {
                return this.rulesField;
            }
            set
            {
                this.rulesField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Rules
    {

        private Rule ruleField;

        /// <remarks/>
        public Rule Rule
        {
            get
            {
                return this.ruleField;
            }
            set
            {
                this.ruleField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Rule
    {

        private string actionIDField;

        private string actionNameField;

        private Condition[] conditionsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ActionID
        {
            get
            {
                return this.actionIDField;
            }
            set
            {
                this.actionIDField = value;
            }
        }

        /// <remarks/>
        public string ActionName
        {
            get
            {
                return this.actionNameField;
            }
            set
            {
                this.actionNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Condition", IsNullable = false)]
        public Condition[] Conditions
        {
            get
            {
                return this.conditionsField;
            }
            set
            {
                this.conditionsField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Condition
    {

        private string transactionIDField;

        private string conditionFieldField;

        private string conditionFieldNameField;

        private string conditionPeriodTypeField;

        private string conditionOperatorField;

        private string conditionOperatorNameField;

        private object[] itemsField;

        private string conditionCurrencyField;

        private Exceptions exceptionsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string TransactionID
        {
            get
            {
                return this.transactionIDField;
            }
            set
            {
                this.transactionIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ConditionField
        {
            get
            {
                return this.conditionFieldField;
            }
            set
            {
                this.conditionFieldField = value;
            }
        }

        /// <remarks/>
        public string ConditionFieldName
        {
            get
            {
                return this.conditionFieldNameField;
            }
            set
            {
                this.conditionFieldNameField = value;
            }
        }

        /// <remarks/>
        public string ConditionPeriodType
        {
            get
            {
                return this.conditionPeriodTypeField;
            }
            set
            {
                this.conditionPeriodTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ConditionOperator
        {
            get
            {
                return this.conditionOperatorField;
            }
            set
            {
                this.conditionOperatorField = value;
            }
        }

        /// <remarks/>
        public string ConditionOperatorName
        {
            get
            {
                return this.conditionOperatorNameField;
            }
            set
            {
                this.conditionOperatorNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ConditionFieldValue", typeof(ConditionFieldValue))]
        [System.Xml.Serialization.XmlElementAttribute("ConditionFieldValueRangeBegin", typeof(ConditionFieldValueRangeBegin))]
        [System.Xml.Serialization.XmlElementAttribute("ConditionFieldValueRangeEnd", typeof(ConditionFieldValueRangeEnd))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        public string ConditionCurrency
        {
            get
            {
                return this.conditionCurrencyField;
            }
            set
            {
                this.conditionCurrencyField = value;
            }
        }

        /// <remarks/>
        public Exceptions Exceptions
        {
            get
            {
                return this.exceptionsField;
            }
            set
            {
                this.exceptionsField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ConditionFieldValue
    {

        private ConditionFieldValueDatatype datatypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ConditionFieldValueDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ConditionFieldValueDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ConditionFieldValueRangeBegin
    {

        private ConditionFieldValueRangeBeginDatatype datatypeField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ConditionFieldValueRangeBeginDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ConditionFieldValueRangeBeginDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ConditionFieldValueRangeEnd
    {

        private ConditionFieldValueRangeEndDatatype datatypeField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ConditionFieldValueRangeEndDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ConditionFieldValueRangeEndDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Exceptions
    {

        private Exception exceptionField;

        /// <remarks/>
        public Exception Exception
        {
            get
            {
                return this.exceptionField;
            }
            set
            {
                this.exceptionField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Exception
    {

        private string exceptionFieldField;

        private string exceptionFieldNameField;

        private string exceptionOperatorField;

        private string exceptionOperatorNameField;

        private object[] itemsField;

        private string exceptionCurrencyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ExceptionField
        {
            get
            {
                return this.exceptionFieldField;
            }
            set
            {
                this.exceptionFieldField = value;
            }
        }

        /// <remarks/>
        public string ExceptionFieldName
        {
            get
            {
                return this.exceptionFieldNameField;
            }
            set
            {
                this.exceptionFieldNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string ExceptionOperator
        {
            get
            {
                return this.exceptionOperatorField;
            }
            set
            {
                this.exceptionOperatorField = value;
            }
        }

        /// <remarks/>
        public string ExceptionOperatorName
        {
            get
            {
                return this.exceptionOperatorNameField;
            }
            set
            {
                this.exceptionOperatorNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ExceptionFieldValue", typeof(ExceptionFieldValue))]
        [System.Xml.Serialization.XmlElementAttribute("ExceptionFieldValueRangeBegin", typeof(ExceptionFieldValueRangeBegin))]
        [System.Xml.Serialization.XmlElementAttribute("ExceptionFieldValueRangeEnd", typeof(ExceptionFieldValueRangeEnd))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        public string ExceptionCurrency
        {
            get
            {
                return this.exceptionCurrencyField;
            }
            set
            {
                this.exceptionCurrencyField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExceptionFieldValue
    {

        private ExceptionFieldValueDatatype datatypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExceptionFieldValueDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute(DataType = "integer")]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ExceptionFieldValueDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExceptionFieldValueRangeBegin
    {

        private ExceptionFieldValueRangeBeginDatatype datatypeField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExceptionFieldValueRangeBeginDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ExceptionFieldValueRangeBeginDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ExceptionFieldValueRangeEnd
    {

        private ExceptionFieldValueRangeEndDatatype datatypeField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ExceptionFieldValueRangeEndDatatype datatype
        {
            get
            {
                return this.datatypeField;
            }
            set
            {
                this.datatypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum ExceptionFieldValueRangeEndDatatype
    {

        /// <remarks/>
        @int,

        /// <remarks/>
        @decimal,

        /// <remarks/>
        date,

        /// <remarks/>
        time,
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ValidChannels
    {

        private Channel[] channelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Channel")]
        public Channel[] Channel
        {
            get
            {
                return this.channelField;
            }
            set
            {
                this.channelField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AllowedTransactions
    {

        private string[] allowedTransactionIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AllowedTransactionID", DataType = "integer")]
        public string[] AllowedTransactionID
        {
            get
            {
                return this.allowedTransactionIDField;
            }
            set
            {
                this.allowedTransactionIDField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Conditions
    {

        private Condition[] conditionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Condition")]
        public Condition[] Condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum ExceptionStatus
    {

        /// <remarks/>
        A,

        /// <remarks/>
        D,

        /// <remarks/>
        P,

        /// <remarks/>
        S,

        /// <remarks/>
        X,
    }
}
