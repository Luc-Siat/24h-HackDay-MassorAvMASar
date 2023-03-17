
export interface IDog {
    dogId: number,
    name: string,
    gender: string,
    imageUrl: string,
    age: number,
    location: string,
    description: string,
    sportId: number,
    userId: number,
    race: string
}

export interface IUser {
    userId: number,
    username: string,
    password: string,
    email: string
}

export interface ISport {
    sportId: number,
    name: string
}

// export interface DogRequest {

// }

