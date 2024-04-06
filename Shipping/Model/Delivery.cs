/*
 * FastAPI
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.0
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
    /// Represents a full delivery, composed of the individual orders. This is a simple composite model to represent all the orders that this is made of.
    /// </summary>
    [DataContract(Name = "Delivery")]
    public partial class Delivery : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets DeliverySla
        /// </summary>
        [DataMember(Name = "delivery_sla", IsRequired = true, EmitDefaultValue = true)]
        public SLA DeliverySla { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Delivery" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Delivery() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Delivery" /> class.
        /// </summary>
        /// <param name="orderId">orderId (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="fulfilledAt">fulfilledAt.</param>
        /// <param name="deliverySla">deliverySla (required).</param>
        public Delivery(Guid orderId = default(Guid), DateTime createdAt = default(DateTime), FulfilledAt fulfilledAt = default(FulfilledAt), SLA deliverySla = default(SLA))
        {
            this.OrderId = orderId;
            this.CreatedAt = createdAt;
            this.DeliverySla = deliverySla;
            this.FulfilledAt = fulfilledAt;
        }

        /// <summary>
        /// Gets or Sets OrderId
        /// </summary>
        [DataMember(Name = "order_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets FulfilledAt
        /// </summary>
        [DataMember(Name = "fulfilled_at", EmitDefaultValue = false)]
        public FulfilledAt FulfilledAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Delivery {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  FulfilledAt: ").Append(FulfilledAt).Append("\n");
            sb.Append("  DeliverySla: ").Append(DeliverySla).Append("\n");
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