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
    /// The service level agreement enum represents the different service level agreements that a shipment can be under.
    /// </summary>
    /// <value>The service level agreement enum represents the different service level agreements that a shipment can be under.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SLA
    {
        /// <summary>
        /// Enum Standard for value: standard
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard = 1,

        /// <summary>
        /// Enum Express for value: express
        /// </summary>
        [EnumMember(Value = "express")]
        Express = 2,

        /// <summary>
        /// Enum Overnight for value: overnight
        /// </summary>
        [EnumMember(Value = "overnight")]
        Overnight = 3,

        /// <summary>
        /// Enum SameDay for value: same_day
        /// </summary>
        [EnumMember(Value = "same_day")]
        SameDay = 4
    }

}
