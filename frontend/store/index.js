import axios from 'axios';
import Vue from "vue";

export const state = () => ({
  tournaments: []
})
  
export const mutations = {
  async init(state, data) {
    state.tournaments = data
  },
  async add(state, data) {
    state.tournaments.push(data)
  },
  async delete(state, data) {
    let delroles = state.tournaments.find(p => p.id === data);
    state.roles.splice(state.roles.indexOf(delroles), 1);
  }
}