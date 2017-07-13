namespace ejercicio11
{
    public interface ITurbomix
    {
        ICocinaUtil cocinaUtil { get; set; }

        Plato CocinarReceta(Alimento alimento1, Alimento alimento2, Receta receta);
    }
}