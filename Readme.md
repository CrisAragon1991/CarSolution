# Reporte de Cobertura y Conocimientos Demostrados

## 📊 Cobertura

**Cobertura alcanzada:** 50%

Resultó imposible abarcar el 70% de la cobertura debido al código generado para las migraciones, el cual no debería ser testeado.

📁 Para abrir el reporte de cobertura, accede al archivo:  
`coverage-report/index.html`

---

## 🧠 Conocimientos Demostrados

- **Arquitectura DDD:** aplicada como base estructural del proyecto.
- **Patrones de diseño:** uso de CQRS y Singleton para separación de responsabilidades y control de instancias.
- **Entity Framework:** implementación de migraciones y Seed en el proyecto de infraestructura.
- **Docker Compose:** utilizado como orquestador entre PostgreSQL y el contenedor del proyecto.
- **Unit Testing:** se alcanzó un porcentaje alto de cobertura en el código que sí debe ser testeado.


Para probar el proyecto solo se debe de ejecutar con el visual studio y abrir http://localhost:8080/swagger/index.html y para ejecutar las pruebas se puede utilizar el explorador de pruebas. Tambien puedes ejecutar el proyecto usando el comando 'docker compose up'