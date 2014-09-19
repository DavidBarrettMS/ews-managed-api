// ---------------------------------------------------------------------------
// <copyright file="CreateRuleOperation.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the CreateRuleOperation class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    /// <summary>
    /// Represents an operation to create a new rule.
    /// </summary>
    public sealed class CreateRuleOperation : RuleOperation
    {
        /// <summary>
        /// Inbox rule to be created.
        /// </summary>
        private Rule rule;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRuleOperation"/> class.
        /// </summary>
        public CreateRuleOperation()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRuleOperation"/> class.
        /// </summary>
        /// <param name="rule">The inbox rule to create.</param>
        public CreateRuleOperation(Rule rule)
            : base()
        {
            this.rule = rule;
        }

        /// <summary>
        /// Gets or sets the rule to be created.
        /// </summary>
        public Rule Rule
        {
            get
            {
                return this.rule;
            }

            set
            {
                this.SetFieldValue<Rule>(ref this.rule, value);
            }
        }

        /// <summary>
        /// Writes elements to XML.
        /// </summary>
        /// <param name="writer">The writer.</param>
        internal override void WriteElementsToXml(EwsServiceXmlWriter writer)
        {
            this.Rule.WriteToXml(writer, XmlElementNames.Rule);
        }

        /// <summary>
        /// Serializes the property to a Json value.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>
        /// A Json value (either a JsonObject, an array of Json values, or a Json primitive)
        /// </returns>
        internal override object InternalToJson(ExchangeService service)
        {
            JsonObject jsonProperty = new JsonObject();

            jsonProperty.Add(XmlElementNames.Rule, this.Rule.InternalToJson(service));

            return jsonProperty;
        }

        /// <summary>
        ///  Validates this instance.
        /// </summary>
        internal override void InternalValidate()
        {
            EwsUtilities.ValidateParam(this.rule, "Rule");
        }

        /// <summary>
        /// Gets the Xml element name of the CreateRuleOperation object.
        /// </summary>
        internal override string XmlElementName
        {
            get
            {
                return XmlElementNames.CreateRuleOperation;
            }
        }
    }
}