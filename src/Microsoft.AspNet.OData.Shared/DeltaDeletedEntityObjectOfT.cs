﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Threading;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Common;
using Microsoft.OData;
using Microsoft.OData.Edm;

namespace Microsoft.AspNet.OData
{
    /// <summary>
    /// Represents an <see cref="IDeltaDeletedEntityObject"/> with a backing CLR <see cref="Type"/>.
    /// Used to hold the Deleted Entry object in the Delta Feed Payload.
    /// </summary>
    [NonValidatingParameterBinding]
    public class DeltaDeletedEntityObject<TStructuralType> : Delta<TStructuralType>, IDeltaDeletedEntityObject where TStructuralType : class
    {
        private string _id;
        private DeltaDeletedEntryReason _reason;

        /// <summary>
        /// Initializes a new instance of <see cref="DeltaDeletedEntityObject{TStructuralType}"/>.
        /// </summary>
        public DeltaDeletedEntityObject()
            : this(typeof(TStructuralType))
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DeltaDeletedEntityObject{TStructuralType}"/>.
        /// </summary>
        /// <param name="structuralType">The derived entity type or complex type for which the changes would be tracked.
        /// <paramref name="structuralType"/> should be assignable to instances of <typeparamref name="TStructuralType"/>.
        /// </param>
        public DeltaDeletedEntityObject(Type structuralType)
            : this(structuralType, dynamicDictionaryPropertyInfo: null, instanceAnnotationsPropertyInfo: null)
        {
        }


        /// <summary>
        /// Initializes a new instance of <see cref="DeltaDeletedEntityObject{TStructuralType}"/>.
        /// </summary>
        /// <param name="structuralType">The derived entity type or complex type for which the changes would be tracked.
        /// <paramref name="structuralType"/> should be assignable to instances of <typeparamref name="TStructuralType"/>.
        /// </param>
        /// <param name="dynamicDictionaryPropertyInfo">The property info that is used as dictionary of dynamic
        /// properties. <c>null</c> means this entity type is not open.</param>        
        /// <param name="instanceAnnotationsPropertyInfo">The property info that is used as container for Instance Annotations</param>
        public DeltaDeletedEntityObject(Type structuralType, PropertyInfo dynamicDictionaryPropertyInfo, PropertyInfo instanceAnnotationsPropertyInfo)
            : base(structuralType, updatableProperties: null , dynamicDictionaryPropertyInfo, instanceAnnotationsPropertyInfo)
        {
 
        }

        /// <inheritdoc />
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <inheritdoc />
        public DeltaDeletedEntryReason Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = (DeltaDeletedEntryReason)value;
            }
        }
    }
}