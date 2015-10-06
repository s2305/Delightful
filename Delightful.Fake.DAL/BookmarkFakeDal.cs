using Delightful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delightful.Fake.Dal
{
   public class BookmarkFakeDal
    {
        public static List<Bookmark> ListBkm { get; private set; }

        //constructeur static (pour une seule execution)
        static BookmarkFakeDal()
        {
            ListBkm = new List<Bookmark>();
            getBookmarks();
        }

        /// <summary>
        /// Remplissage initiale de la liste des Bookmarks
        /// </summary>
        /// <returns></returns>
        public static List<Bookmark> getBookmarks()
        {
            Bookmark bkm1 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Libération...", Description = "Un journal de gauche", Url = "http://www.liberation.fr/" };
            bkm1.Keywords.Add(new Keyword() { BookmarkId = 1, Word = "liberation", Bookmark = bkm1 });
            bkm1.Keywords.Add(new Keyword() { BookmarkId = 2, Word = "journal", Bookmark = bkm1 });
            bkm1.Keywords.Add(new Keyword() { BookmarkId = 3, Word = "gauche", Bookmark = bkm1 });
            ListBkm.Add(bkm1);
            
			Bookmark bkm2 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Le Figaro...", Description = "Un journal de droite", Url = "http://www.lefigaro.fr/" };
            bkm2.Keywords.Add(new Keyword() { BookmarkId = 4, Word = "figaro", Bookmark = bkm2 });
            bkm2.Keywords.Add(new Keyword() { BookmarkId = 5, Word = "journal", Bookmark = bkm2 });
            bkm2.Keywords.Add(new Keyword() { BookmarkId = 6, Word = "droite", Bookmark = bkm2 });
            ListBkm.Add(bkm2);
            
            Bookmark bkm3 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Le Monde", Description = "Le journal historique", Url = "http://www.lemonde.fr/" };
            bkm3.Keywords.Add(new Keyword() { BookmarkId = 7, Word = "monde", Bookmark = bkm3 });
            bkm3.Keywords.Add(new Keyword() { BookmarkId = 8, Word = "journal", Bookmark = bkm3 });
            bkm3.Keywords.Add(new Keyword() { BookmarkId = 9, Word = "reference", Bookmark = bkm3 });
            ListBkm.Add(bkm3);
            

            Bookmark bkm4 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Rue 89", Description = "Un journal en ligne", Url = "http://www.rue89.com/" };
            bkm4.Keywords.Add(new Keyword() { BookmarkId = 10, Word = "news", Bookmark = bkm4 });
            bkm4.Keywords.Add(new Keyword() { BookmarkId = 11, Word = "rue", Bookmark = bkm4 });
            bkm4.Keywords.Add(new Keyword() { BookmarkId = 12, Word = "89", Bookmark = bkm4 });
            ListBkm.Add(bkm4);
            

            Bookmark bkm5 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Le Store d'Apple", Description = "Si tu aimes l'IPad...", Url = "http://store.apple.com/fr" };
            bkm5.Keywords.Add(new Keyword() { BookmarkId = 13, Word = "store", Bookmark = bkm5 });
            bkm5.Keywords.Add(new Keyword() { BookmarkId = 14, Word = "apple", Bookmark = bkm5 });
            bkm5.Keywords.Add(new Keyword() { BookmarkId = 15, Word = "iphone", Bookmark = bkm5 });
            ListBkm.Add(bkm5);
            

            Bookmark bkm6 = new Bookmark() { Id = RechercheIdSuivantPourBookmark(), Title = "Le store de Microsoft...", Description = "Si tu aimes Surface...", Url = "http://www.microsoft.com/hardware/" };
            bkm6.Keywords.Add(new Keyword() { BookmarkId = 16, Word = "store", Bookmark = bkm6 });
            bkm6.Keywords.Add(new Keyword() { BookmarkId = 17, Word = "microsoft", Bookmark = bkm6 });
            bkm6.Keywords.Add(new Keyword() { BookmarkId = 18, Word = "surface", Bookmark = bkm6 });
            ListBkm.Add(bkm6);

            return ListBkm;

        }

        /// <summary>
        /// Ajout d'un bookmark à la liste
        /// </summary>
        /// <param name="b"></param>
        public static void AddBookMark(Bookmark b)
        {
            if (b.Id == 0)
            {
                b.Id = RechercheIdSuivantPourBookmark(); //on renseigne l'id du bookmark , ce n'est pas à l'utilisateur de le faire
            }

            //cette boucle foreach évite d'avoir à renseigner dans le controller toutes les propriétés du keyword
            foreach (var kw in b.Keywords)
            {
                if (kw.Id == 0)
                {
                    kw.Id = RechercheIdSuivantPourKeyword();
                }
                if (kw.BookmarkId == 0)
                {
                    kw.BookmarkId = b.Id;
                }
                if (kw.Bookmark == null)
                {
                    kw.Bookmark = b;
                }
            }

            ListBkm.Add(b);
        }

        #region Recherche des valeurs d'id pour bookmark et keyword
        private static int RechercheMaxIdPourBookmark()
        {
            //J'ai dû faire un petit opérateur ternaire car le max plantait lorsque
            //la collection listBkm était vide
            int maxID = ListBkm.Count == 0 ? 0 : ListBkm.Max(x => x.Id);
            return maxID;
        }

        private static int RechercheIdSuivantPourBookmark()
        {
            return RechercheMaxIdPourBookmark() + 1;
        }

        private static int RechercheMaxIdPourKeyword()
        {
            return ListBkm.SelectMany(x => x.Keywords).Max(y => y.BookmarkId);
        }

        private static int RechercheIdSuivantPourKeyword()
        {
            return RechercheMaxIdPourKeyword() + 1;
        }
        #endregion


    }
}


