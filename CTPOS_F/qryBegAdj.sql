SELECT     tblInventory.lngInventoryID, tblInventory.intCurrentQty, qryBegAdj.intBegAdjQty
FROM         tblInventory LEFT JOIN (

SELECT     SUM(tblAdjustment.intAdjustmentQty) AS intBegAdjQty, tblAdjustment.lngInventoryID, tblAdjustment.lngStoreID
FROM         tblAdjustment
WHERE     (tblAdjustment.dteAdjustmentDate >= CONVERT(DATETIME, '2008-05-01 00:00:00', 102))
GROUP BY tblAdjustment.lngInventoryID, tblAdjustment.lngStoreID) AS qryBegAdj ON tblInventory.lngInventoryID = qryBegAdj.lngInventoryID