package app.service;

import app.domain.dto.ProductDto;
import app.domain.models.Product;
import app.perser.ModelParser;
import app.repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.util.Set;

@Service
public class ProductServiceImpl implements ProductService {

    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private ModelParser modelParser;

    @Override
    public void create(ProductDto productDto) {
        Product product = this.modelParser.convert(productDto, Product.class);
        this.productRepository.saveAndFlush(product);
    }

    @Override
    public void create(Product product) {
        this.productRepository.saveAndFlush(product);
    }

    @Override
    public Product find(Long id) {
        return this.productRepository.findOne(id);
    }

    @Override
    public long getProductsCount() {
        return this.productRepository.count();
    }

    @Override
    public Set<Product> productsInRangeWithoutBuyer(BigDecimal start, BigDecimal end) {
        return this.productRepository.productsInRangeWithoutBuyer(start, end);
    }
}