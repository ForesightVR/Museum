using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MuseumBank
{
    struct GroupProduct
    {
        public string groupTag;
        public List<Artist> productIDs;
    }

    static List<GroupProduct> groupProducts = new List<GroupProduct>();

    public static void GetProducts()
    {

    }
}
