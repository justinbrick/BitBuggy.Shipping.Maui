/*
 * BitBuggy Shipping
 *
 * Management of shipping and delivery information.
 *
 * The version of the OpenAPI document: 2.0.1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = BitBuggy.Shipping.Maui.Shipping.Client.OpenAPIDateConverter;

namespace BitBuggy.Shipping.Maui.Shipping.Model
{
    /// <summary>
    /// A request to create a delivery. A delivery is based under an order, and can have multiple shipments.
    /// </summary>
    [DataContract(Name = "CreateDeliveryRequest")]
    public partial class CreateDeliveryRequest : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets DeliverySla
        /// </summary>
        [DataMember(Name = "delivery_sla", IsRequired = true, EmitDefaultValue = true)]
        public SLA DeliverySla { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDeliveryRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateDeliveryRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDeliveryRequest" /> class.
        /// </summary>
        /// <param name="recipientAddress">recipientAddress (required).</param>
        /// <param name="deliverySla">deliverySla (required).</param>
        /// <param name="items">items (required).</param>
        public CreateDeliveryRequest(string recipientAddress = default(string), SLA deliverySla = default(SLA), List<ShipmentItem> items = default(List<ShipmentItem>))
        {
            // to ensure "recipientAddress" is required (not null)
            if (recipientAddress == null)
            {
                throw new ArgumentNullException("recipientAddress is a required property for CreateDeliveryRequest and cannot be null");
            }
            this.RecipientAddress = recipientAddress;
            this.DeliverySla = deliverySla;
            // to ensure "items" is required (not null)
            if (items == null)
            {
                throw new ArgumentNullException("items is a required property for CreateDeliveryRequest and cannot be null");
            }
            this.Items = items;
        }

        /// <summary>
        /// Gets or Sets RecipientAddress
        /// </summary>
        [DataMember(Name = "recipient_address", IsRequired = true, EmitDefaultValue = true)]
        public string RecipientAddress { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name = "items", IsRequired = true, EmitDefaultValue = true)]
        public List<ShipmentItem> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateDeliveryRequest {\n");
            sb.Append("  RecipientAddress: ").Append(RecipientAddress).Append("\n");
            sb.Append("  DeliverySla: ").Append(DeliverySla).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
