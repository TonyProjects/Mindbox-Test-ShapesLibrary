select P.ProductName, C.CategoryName

from CategoryProduct CP
join Category C on CP.CategoryId = C.CategoryId
right join Product P on CP.ProductId = P.ProductId

order by C.CategoryId, P.ProductId