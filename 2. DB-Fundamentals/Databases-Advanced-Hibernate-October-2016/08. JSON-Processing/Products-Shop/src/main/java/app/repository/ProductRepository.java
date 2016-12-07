package app.repository;

import app.domain.models.Product;
import app.domain.models.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;
import java.math.BigDecimal;
import java.util.Set;

@Repository
@Transactional
public interface ProductRepository extends JpaRepository<Product, Long> {

    @Query(value = "SELECT p FROM Product AS p " +
            "WHERE p.buyer IS NULL AND (p.price BETWEEN :low AND :high) " +
            "ORDER BY p.price ASC")
    Set<Product> productsInRangeWithoutBuyer(@Param(value = "low") BigDecimal low, @Param(value = "high") BigDecimal high);
}