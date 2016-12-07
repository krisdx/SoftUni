//package app.repository;
//
//import org.springframework.data.jpa.repository.Query;
//import org.springframework.data.repository.CrudRepository;
//import org.springframework.stereotype.Repository;
//
//import javax.transaction.Transactional;
//
//@Repository
//@Transactional
//public interface BookRepository extends CrudRepository<Book, Long> {
//    Book findById(Long id);
//
//    Iterable<Book> findAll();
//
//    @Query(value = "SELECT b FROM books AS b" +
//            " WHERE YEAR(b.releaseDate) > :#{[0]}")
//    Iterable<Book> findByReleaseDateYearAfter(int year);
//}