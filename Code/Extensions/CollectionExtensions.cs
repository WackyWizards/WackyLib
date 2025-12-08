using System;
using System.Linq;
using System.Collections.Generic;

namespace Sandbox;

public static class CollectionExtensions
{
	/// <param name="list">
	/// The list whose elements will be shuffled. Its order is modified directly.
	/// </param>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	extension<T>( IList<T> list )
	{
		/// <summary>
		/// Randomizes the order of the elements in the given list in-place
		/// using the Fisher–Yates shuffle algorithm.
		/// </summary>
		public void Shuffle()
		{
			var n = list.Count;
			
			while ( n > 1 )
			{
				n--;
				var k = Game.Random.Next( 0, n + 1 );
				(list[n], list[k]) = (list[k], list[n]);
			}
		}
		
		/// <summary>
		/// Inserts an element into the list at a random position.
		/// </summary>
		/// <param name="item">The element to insert at a random index.</param>
		public void ShuffleInto( T item )
		{
			var n = list.Count;
			var randomIndex = Game.Random.Next( 0, n + 1 );
			list.Insert( randomIndex, item );
		}
	}
	
	extension<T>( IEnumerable<T> enumerable )
	{
		/// <summary>
		/// Combines the hash codes of all elements in the sequence by applying
		/// the given selector and aggregating with <b>HashCode.Combine</b>.
		/// </summary>
		public int HashCombine<TKey>( Func<T, TKey> selector )
		{
			return enumerable.Aggregate( 0, ( current, el ) => HashCode.Combine( current, selector( el ) ) );
		}
	}
}
