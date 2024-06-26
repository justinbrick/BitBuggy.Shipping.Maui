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
    /// An object to be used for patching fields on a shipment.
    /// </summary>
    [DataContract(Name = "ShipmentStatusPatchRequest")]
    public partial class ShipmentStatusPatchRequest : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name = "message", IsRequired = true, EmitDefaultValue = true)]
        public Status Message { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentStatusPatchRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShipmentStatusPatchRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentStatusPatchRequest" /> class.
        /// </summary>
        /// <param name="message">message (required).</param>
        public ShipmentStatusPatchRequest(Status message = default(Status))
        {
            this.Message = message;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipmentStatusPatchRequest {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
