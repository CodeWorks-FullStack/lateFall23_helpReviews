import { Profile } from "./Account.js"



export class Restaurant{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.coverImg = data.coverImg
    this.description = data.description
    this.ownerId = data.ownerId
    this.owner = new Profile(data.owner)
    this.visitCount = data.visitCount
    this.reportCount = data.reportCount
    this.shutdown = data.shutdown
  }
}
