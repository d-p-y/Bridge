namespace Bridge.Html5
{
    /// <summary>
    /// HTML5 WeakMap. Keys must be object (primitives are not allowed). Values can be any type (inc. primitives)
    /// <a href="https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/WeakMap">MDN</a>
    /// </summary>
    [External]
    [Name("WeakMap")]
    public class WeakMap
    {
        /// <summary>
        ///  Default constructor
        /// </summary>
        public WeakMap()
        {
        }

        /// <summary>
        ///  Initialize WeakMap using items that are expected to be an array of the two-element-arrays. Each two-element-array is key and value respecively
        /// Beware that it is not widely implemented (2016-05)
        /// </summary>
        public WeakMap(object[][] items)
        {
        }

        /// <summary>
        /// gets contained element OR returns null. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual extern object Get<T>(T key) where T : class;

        /// <summary>
        /// Sets value. Neither key nor value can be null
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public virtual extern void Set<T>(T key, object value) where T : class;

        /// <summary>
        /// deletes element. Returns true if element was contained in the map. Returns false when it wasn't present in the map
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual extern bool Delete<T>(T key) where T : class;

        public virtual extern bool Has<T>(T key)  where T : class;
    }
}
