namespace MarkEmbling.Utilities {
    public enum ToIntMethod {
        /// <summary>
        /// Discard the fractional component (e.g. 2.9 becomes 2)
        /// </summary>
        IgnoreFraction,

        /// <summary>
        /// Round the number correctly (e.g. 2.9 becomes 3, 2.1 becomes 2)
        /// </summary>
        Round
    }
}