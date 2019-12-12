select e.palabra, i.palabra from Espaniol e
join Traduccion t on t.ca_espaniol = e.c_espaniol
join ingles i on t.ca_ingles = i.c_ingles
where e.palabra = '';