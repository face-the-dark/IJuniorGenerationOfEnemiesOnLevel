# Генерация врагов на уровне

На уровне присутствует несколько точек спавна (создания врагов)

Каждые две секунды в случайной точке спавна должен появляться новый враг
 
После этого он должен начать двигаться по прямой в том направлении, которое ему укажет спавнер

# Продвинутая генерация врагов

Теперь каждая точка спауна создает свой тип врагов и имеет цель, то есть объект, к которому идут враги

В момент создания точка спауна передает врагу свою цель, чтобы тот направился к ней

Таких целей должно быть несколько, у каждого спавнера своя цель

Сами цели движутся по заранее определенному маршруту, от одной точки к другой
