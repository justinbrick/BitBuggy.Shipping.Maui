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
using System.Reflection;

namespace BitBuggy.Shipping.Maui.Shipping.Model
{
    /// <summary>
    /// FulfilledAt
    /// </summary>
    [JsonConverter(typeof(FulfilledAtJsonConverter))]
    [DataContract(Name = "Fulfilled_At")]
    public partial class FulfilledAt : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FulfilledAt" /> class
        /// with the <see cref="DateTime" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of DateTime.</param>
        public FulfilledAt(DateTime actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FulfilledAt" /> class
        /// with the <see cref="Object" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Object.</param>
        public FulfilledAt(Object actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance;
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(DateTime))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(Object))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: DateTime, Object");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `DateTime`. If the actual instance is not `DateTime`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of DateTime</returns>
        public DateTime GetDateTime()
        {
            return (DateTime)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `Object`. If the actual instance is not `Object`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Object</returns>
        public Object GetObject()
        {
            return (Object)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FulfilledAt {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, FulfilledAt.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of FulfilledAt
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of FulfilledAt</returns>
        public static FulfilledAt FromJson(string jsonString)
        {
            FulfilledAt newFulfilledAt = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newFulfilledAt;
            }

            try
            {
                newFulfilledAt = new FulfilledAt(JsonConvert.DeserializeObject<DateTime>(jsonString, FulfilledAt.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newFulfilledAt;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into DateTime: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newFulfilledAt = new FulfilledAt(JsonConvert.DeserializeObject<Object>(jsonString, FulfilledAt.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newFulfilledAt;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into Object: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
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

    /// <summary>
    /// Custom JSON converter for FulfilledAt
    /// </summary>
    public class FulfilledAtJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(FulfilledAt).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return FulfilledAt.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return FulfilledAt.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}