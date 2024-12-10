-- numero de productos vendidos por categoria

-- Select c.category_name from categories c where c.category_id = (select p.category_id, sum(o.quantity) from products p join order_details o on p.product_id = o.product_id group by p.category_id having sum(o.quantity););

SELECT c.category_name, SUM(od.quantity) AS total_products_sold FROM categories c JOIN products p ON c.category_id = p.category_id
JOIN order_details od ON p.product_id = od.product_id GROUP BY c.category_name;

-- total de ingresos generados por cliente

Select  c.customer_name, sum(od.total_price) as Total_Cliente From customers c JOIN order_details od ON c.customer_id = order_id group by c.customer_name;


-- Usar un JOIN para combinar datos de las tablas orders y products.
select * from products left join order_details on products.product_id = order_details.product_id;
-- Encontrar qué producto generó más ingresos:

select p.product_name, sum(o.quantity * p.price) as total from products p join order_details o on p.product_id = o.product_id group by p.product_name having SUM(o.quantity * p.price) >0 ORDER BY total DESC
LIMIT 1;