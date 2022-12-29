Dynamic Bone apply physics to character's bones or joints.
With simple setup, your character's hair, cloth, breasts or any part will move realistically.

Open Assets/DynamicBone/Demo/Demo1 to see how it works.
If you have any questions or suggestions, please contact willhongcom@gmail.com.


-------------------------------------------------------------------------
Basic setup:

1. Prepare a properly setup character, both Mecanim and legacy rigs are supported.
2. Select the game object you want to apply Dynamic Bone.
3. In the component menu, select Dynamic Bone -> Dynamic Bone.
4. In the inspector, select root object.
5. Adjust dynamic bone parameters (see detail descriptions in the following section).


You can add collider objects if required:

1. Select game object the collider will attached.
2. In the component menu, select Dynamic Bone -> Dynamic Bone Collider.
3. Adjust position and size of the collider.
4. In Dynamic Bone component, increase size of colliders and append corresponding object.


-------------------------------------------------------------------------
Dynamic Bone component description:

- Root
  The root of the transform hierarchy to apply physics.

- Roots
  Multiple roots are allowed. They all share the same parameters.

- Update Rate
  Internal physics simulation rate, measures in frames per seconds.

- Update Mode
  Normal: Update physics in fixed timestamp as specified rate.
  AnimatePhysics: Updates during the physic loop in order to synchronized with the physics engine.
  UnscaledTime: Updates independently of Time.timeScale.
  Default: Update physics every frame instead of specified rate, recommended.

- Damping
  How much the bones slowed down.

- Elasticity
  How much the force applied to return each bone to original orientation.

- Stiffness
  How much bone's original orientation are preserved.

- Inert
  How much character's position change is ignored in physics simulation.

- Friction
  How much the bones slowed down when collide.

- Radius
  Each bone can be a sphere to collide with colliders. Radius describe sphere's size.

- Damping Distrib, Elasticity Distrib, Stiffness Distrib, Inert Distrib, Radius Distrib
  How parameters change over hierarchy chain. Curve values are multiplied to corresponding parameters. 

- End Length
  If End Length is not zero, an extra bone is generated at the end of transform hierarchy, 
  length is multiplied by last two bone's distance.

- End Offset
  If End Offset is not zero, an extra bone is generated at the end of transform hierarchy, 
  offset is in character's local space.

- Gravity
  The force apply to bones, in world space. Partial force apply to character's initial pose is cancelled out.

- Force
  The force apply to bones, in world space.

- Blend Weight
  Control how physics blends with existing animation.

- Colliders
  Collider objects interact with the bones.

- Exclusions
  Bones exclude from physics simulation.
     
- Freeze Axis
  Constrain bones to move on specified plane.

- Distant Disable, Reference Object, Distance To Object
  Disable physics simulation automatically if character is far from camera or player.
  If there is no reference object, default main camera is used.

Dynamic Bone Collider component description:

- Center
  The center of the sphere or capsule, in the object's local space.

- Radius
  The radius of the sphere or capsule, will be scaled by the transform's scale.

- Height
  The height of the capsule, including two half-spheres, will be scaled by the transform's scale.

- Radius 2
  The other radius of the capsule. 0 means same as Radius.

- Direction
  The axis of the capsule's height.

- Bound
  Constrain bones to outside bound or inside bound.

-------------------------------------------------------------------------
Dynamic Bone script reference:

- public void SetWeight(float w);
  Control how physics blend with existing animation.

- public void UpdateParameters();
  Update parameters at runtime, call this funtion after modifing parameters.

- public bool m_Multithread
  Enable/disable multithread to improve physics simulation performace. Default is true.
-------------------------------------------------------------------------
Version History

1.0.1 Initial release.
1.0.2 Improve inspector UI.
1.0.3 Fix inert unstable when enabled / disabled.
1.1.0 Use curve to setup parameters over hierarchy chain.
      Collider can configured to constrain bones inside bound.
1.1.1 Add exclusion setting.
1.1.2 Deal with negative scale problem.
1.1.3 Fix bug with bones contain scale.
1.1.4 Add freeze axis.
      Fix bug when added via script.
1.1.5 Add distant disable.
      Reduce GC alloc.
1.1.6 Fix capsule collider bug.
1.1.7 Unity 5 support.
1.1.8 Fix problems caused by negative scale.
1.1.9 Improve detecting negative scale.
      Fix bug if collider is set as inside.
      Add UpdateMode setting.
1.1.10 Fix problems caused by negative scale after Unity 5.4.
1.2.0 Add tool tips.
      Add plane collider.
      Add function to update parameters at runtime.
1.2.1 Add friction parameter.
      Update UNITY_5 to compatible with newer version.
1.2.2 Add "Default" update mode, fix some jitter issue.
1.3.0 Add "Roots" parameter to setup multiple root transforms.
      Add "Blend Weight" parameter to control how physics blends with existing animation.
      Collider add enable/disable check box.
      Collider add "Radius 2" to setup capsules of two radii.      
      Use multithread to improve physics simulation performance.
      Parameters can be animated with Unity animation system.
1.3.1 Fix "Gravity" bug in version 1.3.0
1.3.2 Disable multithread in WebGL build.


동적 골격은 캐릭터의 뼈나 관절에 물리학을 적용한다.
간단한 설정으로 캐릭터의 머리카락, 천, 가슴 또는 모든 부분이 사실적으로 움직입니다.

Assets/DynamicBone/Demo/Demo1을 열어 작동 방식을 확인합니다.
질문이나 제안이 있으면 willhongcom@gmail.com으로 문의하십시오.


-------------------------------------------------------------------------
기본 설정:

1. 올바르게 설정된 캐릭터를 준비하십시오. Mecanim과 레거시 리그가 모두 지원됩니다.
2. Dynamic Bone을 적용할 게임 개체를 선택합니다.
3. 구성 요소 메뉴에서 Dynamic Bone -> Dynamic Bone을 선택합니다.
4. 검사기에서 루트 개체를 선택합니다.
5. 동적 골격 파라미터를 조정합니다(다음 섹션의 세부 설명 참조).


필요한 경우 충돌기 개체를 추가할 수 있습니다.

1. 충돌기가 부착할 게임 객체를 선택합니다.
2. 구성 요소 메뉴에서 Dynamic Bone(동적 골격) -> Dynamic Bone Collider(동적 골격 충돌기)를 선택합니다.
3. Collider의 위치와 크기를 조정합니다.
4. Dynamic Bone 구성 요소에서 충돌기의 크기를 늘리고 해당 개체를 추가합니다.


-------------------------------------------------------------------------
Dynamic Bone 구성 요소 설명:

- 뿌리
  물리학을 적용할 변환 계층의 루트입니다.

- 뿌리
  루트가 여러 개 허용됩니다. 모두 동일한 매개 변수를 공유합니다.

- 업데이트 속도
  내부 물리 시뮬레이션 속도, 초당 프레임 단위로 측정합니다.

- 업데이트 모드
  정상: 지정된 속도로 고정된 타임스탬프의 물리학을 업데이트합니다.
  애니메이션물리학: 물리 엔진과 동기화하기 위해 물리 루프 중에 업데이트합니다.
  Unscaleed Time: Time.timeScale과 독립적으로 업데이트합니다.
  기본값: 지정된 속도 대신 모든 프레임에 물리 업데이트를 권장합니다.

- 댐핑
  뼈가 얼마나 느려졌는지.

- 탄력성
  각 뼈를 원래 방향으로 되돌리는 데 적용된 힘의 양입니다.

- 강성
  뼈의 원래 방향이 얼마나 보존되어 있는지.

- 불활성
  물리 시뮬레이션에서 캐릭터의 위치 변화가 얼마나 무시되는가.

- 마찰
  충돌할 때 뼈가 얼마나 느려졌는가.

- 반지름
  각각의 뼈는 충돌기와 충돌하는 구체가 될 수 있다. 반지름은 구의 크기를 나타냅니다.

- 댐핑 분포, 탄성 분포, 강성 분포, 불활성 분포, 반지름 분포
  계층 체인을 통해 매개 변수가 변경되는 방식. 원곡선 값이 해당 파라미터에 곱됩니다. 

- 끝 길이
  End Length(종료 길이)가 0이 아닌 경우 변환 계층 구조의 끝에서 추가 골격이 생성됩니다. 
  길이는 마지막 두 뼈의 거리를 곱한다.

- 끝 간격띄우기
  End Offset(오프셋 종료)이 0이 아닌 경우 변환 계층 구조의 끝에서 추가 골격이 생성됩니다. 
  오프셋은 문자의 로컬 공간에 있습니다.

- 중력
  그 힘은 세계 공간에서 뼈에 적용된다. 캐릭터의 초기 포즈에 가해지는 부분적인 힘이 취소됩니다.

- 포스
  그 힘은 세계 공간에서 뼈에 적용된다.

- 혼합 무게
  물리학이 기존 애니메이션과 혼합되는 방식을 제어합니다.

- 충돌기
  충돌기 물체는 뼈와 상호작용한다.

- 제외사항
  뼈는 물리 시뮬레이션에서 제외됩니다.
     
- 축 고정
  지정된 평면에서 이동하도록 본을 구속합니다.

- 원격 비활성화, 참조 객체, 객체와의 거리
  캐릭터가 카메라나 플레이어에서 멀리 떨어져 있는 경우 물리 시뮬레이션을 자동으로 비활성화합니다.
  기준 개체가 없는 경우 기본 주 카메라가 사용됩니다.

Dynamic Bone Collider 구성 요소 설명:

- 센터
  개체의 로컬 공간에 있는 구체 또는 캡슐의 중심입니다.

- 반지름
  구체 또는 캡슐의 반지름은 변환의 축척에 따라 조정됩니다.

- 키
  두 개의 반구체를 포함한 캡슐의 높이는 변환의 규모에 의해 조정될 것이다.

- 반지름 2
  캡슐의 다른 반경입니다. 0은 Radius와 같은 의미입니다.

- 방향
  캡슐 높이의 축입니다.

- 바운드
  뼈를 바깥쪽 또는 안쪽 경계로 구속합니다.

-------------------------------------------------------------------------
동적 골격 스크립트 참조:

- 공공 보이드 세트 중량(플로트);
  물리학이 기존 애니메이션과 혼합되는 방식을 제어합니다.

- 공개 void 업데이트 매개 변수();
  런타임에 매개 변수 업데이트, 매개 변수를 수정한 후 이 함수를 호출합니다.

- 공황_멀티스레드
  멀티 스레드를 활성화/비활성화하여 물리 시뮬레이션 성능을 향상시킵니다. 기본값은 true입니다.
-------------------------------------------------------------------------
버전 기록

1.0.1 초기 릴리스.
1.0.2 검사자 UI를 개선한다.
1.0.3 활성화/비활성화 시 불활성 불안정성을 수정한다.
1.1.0 curve를 사용하여 계층 체인에 대한 파라미터를 설정합니다.
      충돌기는 바인딩 내부의 뼈를 구속하도록 구성할 수 있습니다.
1.1.1 제외 설정을 추가한다.
1.1.2 음의 척도 문제를 처리한다.
1.1.3 Fix bug with bone에는 비늘이 포함되어 있다.
1.1.4 동결축을 추가한다.
      스크립트를 통해 추가할 때 버그를 수정합니다.
1.1.5 원격 비활성화 추가.
      GC 할당을 줄입니다.
1.1.6 캡슐 충돌기 버그를 수정한다.
1.1.7 Unity 5 지원.
1.1.8 음의 척도로 인한 문제를 수정한다.
1.1.9 음의 척도를 검출하는 방법을 개선한다.
      충돌기가 다음과 같이 설정된 경우 버그 수정