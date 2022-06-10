CREATE PROCEDURE sp_full_products
AS
BEGIN  
  select p.Id, c.Name 'CategoryName', p.Name, p.Price, pf.Width, pf.Height from Products p
  join Categories c on p.CategoryId=c.Id
  join ProductFeatures pf on pf.Id=p.Id
END