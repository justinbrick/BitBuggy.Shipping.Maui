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
    /// The shipment model represents a shipment that has been created for a specific order. Multiple shipments can be created for one order.
    /// </summary>
    [DataContract(Name = "Shipment")]
    public partial class Shipment : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Provider
        /// </summary>
        [DataMember(Name = "provider", IsRequired = true, EmitDefaultValue = true)]
        public Provider Provider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Shipment" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Shipment() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Shipment" /> class.
        /// </summary>
        /// <param name="shipmentId">shipmentId (required).</param>
        /// <param name="fromAddress">fromAddress (required).</param>
        /// <param name="shippingAddress">shippingAddress (required).</param>
        /// <param name="provider">provider (required).</param>
        /// <param name="providerShipmentId">providerShipmentId (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="items">items (required).</param>
        public Shipment(Guid shipmentId = default(Guid), string fromAddress = default(string), string shippingAddress = default(string), Provider provider = default(Provider), string providerShipmentId = default(string), DateTime createdAt = default(DateTime), List<ShipmentItem> items = default(List<ShipmentItem>))
        {
            this.ShipmentId = shipmentId;
            // to ensure "fromAddress" is required (not null)
            if (fromAddress == null)
            {
                throw new ArgumentNullException("fromAddress is a required property for Shipment and cannot be null");
            }
            this.FromAddress = fromAddress;
            // to ensure "shippingAddress" is required (not null)
            if (shippingAddress == null)
            {
                throw new ArgumentNullException("shippingAddress is a required property for Shipment and cannot be null");
            }
            this.ShippingAddress = shippingAddress;
            this.Provider = provider;
            // to ensure "providerShipmentId" is required (not null)
            if (providerShipmentId == null)
            {
                throw new ArgumentNullException("providerShipmentId is a required property for Shipment and cannot be null");
            }
            this.ProviderShipmentId = providerShipmentId;
            this.CreatedAt = createdAt;
            // to ensure "items" is required (not null)
            if (items == null)
            {
                throw new ArgumentNullException("items is a required property for Shipment and cannot be null");
            }
            this.Items = items;
        }

        /// <summary>
        /// Gets or Sets ShipmentId
        /// </summary>
        [DataMember(Name = "shipment_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid ShipmentId { get; set; }

        /// <summary>
        /// Gets or Sets FromAddress
        /// </summary>
        [DataMember(Name = "from_address", IsRequired = true, EmitDefaultValue = true)]
        public string FromAddress { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddress
        /// </summary>
        [DataMember(Name = "shipping_address", IsRequired = true, EmitDefaultValue = true)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// Gets or Sets ProviderShipmentId
        /// </summary>
        [DataMember(Name = "provider_shipment_id", IsRequired = true, EmitDefaultValue = true)]
        public string ProviderShipmentId { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

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
            sb.Append("class Shipment {\n");
            sb.Append("  ShipmentId: ").Append(ShipmentId).Append("\n");
            sb.Append("  FromAddress: ").Append(FromAddress).Append("\n");
            sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  ProviderShipmentId: ").Append(ProviderShipmentId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
