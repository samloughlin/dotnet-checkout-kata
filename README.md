# dotnet-checkout-kata
Basic implementation of the checkout kata


### Possible Improvements
Given more time I would have made the following improvements:
- Simplify discount calculation logic. Current implementation made up of a fairly nasty loop, and also modifies the input variables. 
Something like this might be a bit nicer:
 
 ```
while(true){
    var things =  itemsToProcess.Where(s => s.Sku == offer.Sku).Take(offer.Quantity).ToList();
    if (things.Count() != offer.Quantity) break;
    itemsToProcess = itemsToProcess.Except(things).ToList();
    total += offer.OfferPrice;
}
```

- Move calculation logic out of the checkout and into own calculation class
  - This would have allowed me to have separate implementations for a version that supports discounts and one that doesn't
  - Discount logic could have also been moved into separate class
 
