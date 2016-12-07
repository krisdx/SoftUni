package app.terminal;

import app.domain.dto.ProductDto;
import app.domain.models.Product;
import app.perser.JsonParser;
import app.perser.ModelParser;
import app.service.ProductService;
import org.modelmapper.PropertyMap;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.math.BigDecimal;
import java.util.Set;

@Component
public class ExportJsonTerminal implements CommandLineRunner {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private JsonParser jsonParser;

    @Autowired
    private ProductService productService;

    @Override
    public void run(String... strings) throws Exception {
        productsInRange(new BigDecimal("500"), new BigDecimal("1000"));
    }

    private void productsInRange(BigDecimal start, BigDecimal end) {
        Set<Product> products =
                this.productService.productsInRangeWithoutBuyer(start, end);
        PropertyMap<Product, ProductDto> propertyMap = new PropertyMap<Product, ProductDto>() {
            @Override
            protected void configure() {
                map(source.getSeller().getFullName(), destination.getSellerName());
            }
        };

        Set<ProductDto> productDtos = this.modelParser.convertCollection(products, ProductDto.class, propertyMap);

        try {
            this.jsonParser.exportToJson(productDtos,
                    "src/main/resources/files/output/json/products-in-range.json");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}