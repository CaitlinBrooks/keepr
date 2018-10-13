import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    keepsById: [],
    currentVault: {},
    vaultkeeps: []
  },
  mutations: {
    setVaultById(state, vault) {
      state.currentVault = vault
    },
    setKeepsByUserId(state, keepsById) {
      state.keepsById = keepsById
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps
    },
    setUser(state, user) {
      state.user = user
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'login' })
        })
    },
    // KEEPS
    newKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
        .then(res => {
          dispatch('getAllKeeps')
        })
    },
    updateKeep({ commit, dispatch }, keep) {
      api.put('keeps' + keep.id, keep)
        .then(res => {
          dispatch('getAllKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, keepData) {
      api.post("keeps", keepData.id)
        .then(res => {
          dispatch('getAllKeeps')
        })
    },
    getKeepsByUserId({ commit }, userId) {
      api.get("keeps/" + userId)
        .then(res => {
          commit("setKeepsByUserId", res.data)
        })
    },
    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get("keeps/vault/" + vaultId)
        .then(res => {
          commit("setKeepsByVaultId", res.data)
        })
    },
    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data) // this is public, would need to be used before logging in and then getbyId would be for user specifically.
        })
    },

    // VAULTS
    moveToVaults() {
      router.push({ name: 'vaults' })
    },
    newVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(res => {
          dispatch('getAllVaults')
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete("vaults/", vaultId)
        .then(res => {
          dispatch('getAllVaults')
        })
    },
    getVaultById({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          commit("setVaultById", res.data)
        })
    },
    getAllVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
  }
})

