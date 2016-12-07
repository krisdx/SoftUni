package app.service;

import app.domain.dto.ProductDto;
import app.domain.models.Product;

import java.math.BigDecimal;
import java.util.Set;

public interface ProductService {
    void create(ProductDto productDto);

    void create(Product product);

    Product find(Long id);

    long getProductsCount();

    Set<Product> productsInRangeWithoutBuyer(BigDecimal start, BigDecimal end);
}