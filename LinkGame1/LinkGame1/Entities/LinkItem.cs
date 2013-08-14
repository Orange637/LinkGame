// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkItem.cs" company="MM Software GmbH">
//   (C) by MM Software GmbH. All rights reserved.
// </copyright>
// <summary>
//   The link item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using LinkGame1.Common;

namespace LinkGame1.Entities
{
    /// <summary>
    /// The link item.
    /// </summary>
    public class LinkItem : ObservableObject, IMapItem
    {
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is dead.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value { get; set; }
    }
}