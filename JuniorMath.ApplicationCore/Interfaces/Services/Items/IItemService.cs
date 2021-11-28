using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.DTOs.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.Items
{
    public interface IItemService
    {
        Result SaveItem(ItemModel itemModel);

        List<ItemModel> SearchItems();

        ItemModel SearchItem(int id);
        bool HasSubscriptionItems(List<int> itemIds);
    }
}
