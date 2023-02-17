# BloomFilter

Uso da Estrutura de Dados Bloom Filter baseado em um vídeo do Elemar Jr feito em seu canal do Youtube.

Sobre o Bloom Filter:
  - é uma estrutura de dados probalística;
  - é utilizada para testar se um elemento está presente em um conjunto sem necessitar consultar a lista completa de elementos presentes nesse conjunto;
    - garante 100% de certeza que não está;
    - apresenta falsos positivos que está;
  - utiliza hashes de qualidade para ligar ou desligar os bits em um mapa;
    - sempre que um dado é incluído no filtro, os bits correspondentes do hash são ligados;
    
Pode ser utilizado para saber se uma string ou int está presente em uma coleção.. como email, senha, ID, etc...

Utilizado em caches.

# Referências: 
  - https://www.youtube.com/watch?v=sqV1kwBJdWE&list=PLSkWUglft13Ti2UetxBKldlnhhPALh2tt&index=27&ab_channel=ElemarJunior
  - https://eximia.co/como-bloom-filter-pode-ser-utilizada-para-melhorar-a-performance/
