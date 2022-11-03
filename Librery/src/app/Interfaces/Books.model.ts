export interface Book {
  id: number;
  title: string;
  description: string;
  price: number;
  publicationDate?: Date;
  autor: {
    id: string,
    nameComplet: string
  };
}
