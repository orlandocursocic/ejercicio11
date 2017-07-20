namespace ejercicio11
{
    public interface ITurbomix
    {
        ICocinaUtilService cocinaUtilService { get; set; }

        Plato CocinarReceta(Alimento alimento1, Alimento alimento2, Receta receta);

        void addRecetaRepositorio(Receta receta);
    }
}