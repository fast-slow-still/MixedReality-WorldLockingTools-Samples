﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace Microsoft.MixedReality.WorldLocking.Core
{
    /// <summary>
    /// Settings related to management of the internal anchor graph.
    /// </summary>
    [System.Serializable]
    public struct AnchorSettings 
    {
        [SerializeField]
        [Tooltip("Ignore set values and use default behavior. When set, will reset all values to defaults.")]
        private bool useDefaults;

        /// <summary>
        /// Ignore set values and use default behavior. When set, will reset all values to defaults.
        /// </summary>
        public bool UseDefaults
        {
            get { return useDefaults; }
            set
            {
                useDefaults = value;
                if (useDefaults)
                {
                    InitToDefaults();
                }
            }
        }

        /// <summary>
        /// Check the validity of the settings.
        /// </summary>
        public bool IsValid
        {
            get { return MinNewAnchorDistance > 0 && MaxAnchorEdgeLength > MinNewAnchorDistance; }
        }

        /// <summary>
        /// The minimum distance to the current closest anchor before creating a new anchor.
        /// </summary>
        /// <remarks>
        /// A greater value will result in a less dense anchor coverage.
        /// </remarks>
        [Tooltip("The minimum distance to the current closest anchor before creating a new anchor.")]
        public float MinNewAnchorDistance;

        /// <summary>
        /// The maximum distance between two anchors to connect them with a graph edge.
        /// </summary>
        /// <remarks>
        /// This must be greater than MinNewAnchorDistance to create a connected graph of anchors.
        /// </remarks>
        [Tooltip("The maximum distance between two anchors to connect them with a graph edge.")]
        public float MaxAnchorEdgeLength;

        /// <summary>
        /// Init all fields to default values.
        /// </summary>
        public void InitToDefaults()
        {
            useDefaults = true;
            MinNewAnchorDistance = 1.0f;
            MaxAnchorEdgeLength = 1.2f;
        }
    }
}