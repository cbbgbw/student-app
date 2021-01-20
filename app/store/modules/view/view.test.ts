import create, { UseStore } from 'zustand'
import { combined, StateCombined } from '../modules'
import { beforeEach, expect, describe, it } from '@jest/globals'
import { ModalType } from '../../../types/types'
import { getViewState } from '../user/userSelectors'

describe('View actions', () => {
  let store: UseStore<StateCombined>
  beforeEach(() => {
    store = create(combined)
  })

  it('setModalType', () => {
    const newModalType = ModalType.AddSubject

    getViewState(store.getState()).setModalType(newModalType)

    expect(getViewState(store.getState()).modalType).toEqual(newModalType)
  })
})
