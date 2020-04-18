using System;

namespace HarryPotterKata
{
    public class Book
    {
        public double Price { get; } = 8;
        public string Volume { get; }

        public Book(string volume)
        {
            Volume = volume;
        }

        public override bool Equals(object obj)
        {
            // Is null?
            if (obj is null)
            {
                return false;
            }

            // Is the same object?
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // Is the same type?
            return obj.GetType() == this.GetType() && IsEqual((Book)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Volume);
        }

        private bool IsEqual(Book book)
        {
            // A pure implementation of value equality that avoids the routine checks above
            // We use String.Equals to really drive home our fear of an improperly overridden "=="
            return string.Equals(Volume, book.Volume)
                   && Equals(Price, book.Price);
        }
    }
}
