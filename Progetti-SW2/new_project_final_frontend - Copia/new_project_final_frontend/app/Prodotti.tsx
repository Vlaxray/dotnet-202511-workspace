type Meal = {
  name: string;
  category: string;
  area: string;
  instructions: string;
  thumbnail: string;
};

export default function Prodotti({ meal }: { meal: Meal }) {
  return (
    <div className="card mt-4">
      <img src={meal.thumbnail} className="card-img-top" />
      <div className="card-body">
        <h5 className="card-title">{meal.name}</h5>
        <p className="card-text">
          {meal.category} · {meal.area}
        </p>
        <p className="card-text small">
          {meal.instructions}
        </p>
      </div>
    </div>
  );
}
