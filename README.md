# SubmitProject
 트러블슈팅이 너무 간단해서 TIL로 작성하지 않아 간단하게 여기에 작성하겠습니다
Interaction.cs 에 if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask)) 부분에서
처음에 layerMask 를 작성하지 않아, 땅을 봐도 nullReference가 뜨거나 기존에 텍스트가 남아있는등 버그가 발생하여
레이어마스크를 추가하게 됐습니다.
