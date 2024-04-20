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
    /// A shipment item that is related to a given shipment. There can be multiple items associated with one shipment.
    /// </summary>
    [DataContract(Name = "ShipmentItem")]
    public partial class ShipmentItem : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentItem" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShipmentItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentItem" /> class.
        /// </summary>
        /// <param name="upc">upc (required).</param>
        /// <param name="stock">stock (required).</param>
        public ShipmentItem(int upc = default(int), int stock = default(int))
        {
            this.Upc = upc;
            this.Stock = stock;
        }

        /// <summary>
        /// Gets or Sets Upc
        /// </summary>
        [DataMember(Name = "upc", IsRequired = true, EmitDefaultValue = true)]
        public int Upc { get; set; }

        /// <summary>
        /// Gets or Sets Stock
        /// </summary>
        [DataMember(Name = "stock", IsRequired = true, EmitDefaultValue = true)]
        public int Stock { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipmentItem {\n");
            sb.Append("  Upc: ").Append(Upc).Append("\n");
            sb.Append("  Stock: ").Append(Stock).Append("\n");
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
